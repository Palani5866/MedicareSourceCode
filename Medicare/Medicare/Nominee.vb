Public Class Nominee
    Dim Conn As DbConnection = New SqlConnection
    Dim ds_Member As New DataSet
    Dim objBusi As New Business
    Dim otitle, oName, oDOB, oNRIC, oAdd1, oAdd2, oAdd3, oAdd4, oTown, oState, oPoscode, oShare As String
    Dim oeShare As Decimal
    Private Sub Nominee_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub Nominee_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.cbRelationship.SelectedIndex = 0
        If Me.lblGUID.Text = "" Then
            getNomineeDetails(Me.lblNomineeID.Text)
            Me.btnSubmit.Name = "Update"
            Me.btnSubmit.Text = "Update"
            Me.btnDelete.Visible = True
            Me.lblRemarks.Visible = True
            Me.txtRemarks.Visible = True
        Else
            Me.btnSubmit.Name = "Submit"
            Me.btnSubmit.Text = "Submit"
            Me.btnDelete.Visible = False
            Me.lblRemarks.Visible = False
            Me.txtRemarks.Visible = False
        End If
    End Sub
    Private Sub getNomineeDetails(ByVal NomineeID As String)
        Dim dt As New DataTable
        dt = objBusi.getDetails("MEMBER", NomineeID, "", "", "ENSGET", "ENS", Conn)
        If dt.Rows.Count > 0 Then
            Me.lblGUID.Text = dt.Rows(0)("MPID").ToString().Trim()
            Me.lblMemberID.Text = dt.Rows(0)("MID").ToString().Trim()
            If Not IsDBNull(dt.Rows(0)("Title")) Then
                Me.txtNominee_Title.Text = dt.Rows(0)("Title")
                otitle = dt.Rows(0)("Title")
            Else
                Me.txtNominee_Title.Text = ""
            End If
            If Not IsDBNull(dt.Rows(0)("Full_Name")) Then
                Me.txtNominee_Name.Text = dt.Rows(0)("Full_Name")
                oName = dt.Rows(0)("Full_Name")
            Else
                Me.txtNominee_Name.Text = ""
            End If
            If Not IsDBNull(dt.Rows(0)("Birth_Date")) Then
                Me.dtpNominee_DOB.Value = dt.Rows(0)("Birth_Date")
                oDOB = dt.Rows(0)("Birth_Date")
            Else
                Me.dtpNominee_DOB.Value = Today()
            End If
            If Not IsDBNull(dt.Rows(0)("IC_New")) Then
                Me.txtNominee_NRIC.Text = dt.Rows(0)("IC_New")
                oNRIC = dt.Rows(0)("IC_New")
            Else
                Me.txtNominee_NRIC.Text = ""
            End If
            If Not IsDBNull(dt.Rows(0)("Relationship")) Then
                Dim Relation As String
                Relation = dt.Rows(0)("Relationship")
                Select Case Relation
                    Case "Spouse"
                        Me.cbRelationship.SelectedIndex = 0
                    Case "Children"
                        Me.cbRelationship.SelectedIndex = 1
                    Case "Relative"
                        Me.cbRelationship.SelectedIndex = 2
                    Case "Others"
                        Me.cbRelationship.SelectedIndex = 3
                End Select
            End If
            If Not IsDBNull(dt.Rows(0)("Add1")) Then
                If Not IsDBNull(dt.Rows(0)("Add1")) Then
                    Me.txtNAdd1.Text = dt.Rows(0)("Add1").ToString.Trim()
                Else
                    Me.txtNAdd1.Text = ""
                End If

                If Not IsDBNull(dt.Rows(0)("Add2")) Then
                    Me.txtNAdd2.Text = dt.Rows(0)("Add2").ToString.Trim()
                Else
                    Me.txtNAdd2.Text = ""
                End If
                If Not IsDBNull(dt.Rows(0)("Add3")) Then
                    Me.txtNAdd3.Text = dt.Rows(0)("Add3").ToString.Trim()
                Else
                    Me.txtNAdd3.Text = ""
                End If
                If Not IsDBNull(dt.Rows(0)("Add4")) Then
                    Me.txtNAdd4.Text = dt.Rows(0)("Add4").ToString.Trim()
                Else
                    Me.txtNAdd4.Text = ""
                End If
                If Not IsDBNull(dt.Rows(0)("Town")) Then
                    Me.txtNTown.Text = dt.Rows(0)("Town").ToString.Trim()
                Else
                    Me.txtNTown.Text = ""
                End If
                If Not IsDBNull(dt.Rows(0)("State")) Then
                    Me.txtNState.Text = dt.Rows(0)("State").ToString.Trim()
                Else
                    Me.txtNState.Text = ""
                End If
                If Not IsDBNull(dt.Rows(0)("Poscode")) Then
                    Me.txtNPoscode.Text = dt.Rows(0)("Poscode").ToString.Trim()
                Else
                    Me.txtNPoscode.Text = ""
                End If
            Else
                If Not IsDBNull(dt.Rows(0)("Postal_Address")) Then
                    Me.txtNAdd1.Text = dt.Rows(0)("Postal_Address")
                Else
                    Me.txtNAdd1.Text = ""
                End If
            End If
            If Not IsDBNull(dt.Rows(0)("Add1")) Then
                oAdd1 = dt.Rows(0)("Add1").ToString.Trim()
            Else
                oAdd1 = ""
            End If

            If Not IsDBNull(dt.Rows(0)("Add2")) Then
                oAdd2 = dt.Rows(0)("Add2").ToString.Trim()
            Else
                oAdd2 = ""
            End If

            If Not IsDBNull(dt.Rows(0)("Add3")) Then
                oAdd3 = dt.Rows(0)("Add3").ToString.Trim()
            Else
                oAdd3 = ""
            End If
            If Not IsDBNull(dt.Rows(0)("Add4")) Then
                oAdd4 = dt.Rows(0)("Add4").ToString.Trim()
            Else
                oAdd4 = ""
            End If

            If Not IsDBNull(dt.Rows(0)("Town")) Then
                oTown = dt.Rows(0)("Town").ToString.Trim()
            Else
                oTown = ""
            End If
            If Not IsDBNull(dt.Rows(0)("State")) Then
                oState = dt.Rows(0)("State").ToString.Trim()
            Else
                oState = ""
            End If

            If Not IsDBNull(dt.Rows(0)("Poscode")) Then
                oPoscode = dt.Rows(0)("Poscode").ToString.Trim()
            Else
                oPoscode = ""
            End If

            If Not IsDBNull(dt.Rows(0)("Share")) Then
                Me.txtNominee_SharePercentage.Text = dt.Rows(0)("Share")
                oShare = dt.Rows(0)("Share")
                oeShare = dt.Rows(0)("Share")
            Else
                Me.txtNominee_SharePercentage.Text = ""
            End If

            If Not IsDBNull(dt.Rows(0)("Effective_Date")) Then
                Me.dtpEffectiveDate.Value = dt.Rows(0)("Effective_Date")
            End If
        End If
    End Sub
    Private Sub btnNominee_Title_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNominee_Title.Click
        Dim frmSearch_Title As New frmSearch_Param
        frmSearch_Title.lblForm_Flag.Text = "T"
        frmSearch_Title.ShowDialog()

        Me.txtNominee_Title.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
    Private Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If Me.btnSubmit.Name = "Update" Then
            ups_Nominee()
        Else
            ins_Nominee()
        End If
    End Sub
    Private Function chkValidation() As Boolean
        If Me.txtNominee_Title.Text.ToString.Trim() = "" Then
            MsgBox("Title Can't be Blank!")
            Me.txtNominee_Title.Focus()
            Return False
        End If
        If Me.txtNominee_Name.Text.ToString.Trim() = "" Then
            MsgBox("Name Can't be Blank!")
            Me.txtNominee_Name.Focus()
            Return False
        End If
        If Me.txtNominee_NRIC.Text.ToString.Trim() = "" Then
            MsgBox("IC Number Can't be Blank!")
            Me.txtNominee_NRIC.Focus()
            Return False
        End If
        If Me.txtNAdd1.Text.ToString.Trim() = "" Then
            MsgBox("Address Can't be Blank!")
            Me.txtNAdd1.Focus()
            Return False
        End If
        If Me.txtNAdd2.Text.ToString.Trim() = "" Then
            MsgBox("Address2 Can't be Blank!")
            Me.txtNAdd2.Focus()
            Return False
        End If
        If Me.txtNPoscode.Text.ToString.Trim() = "" Then
            MsgBox("POS CODE Can't be Blank!")
            Me.txtNPoscode.Focus()
            Return False
        End If
        If Me.txtNState.Text.ToString.Trim() = "" Then
            MsgBox("STATE Can't be Blank!")
            Me.txtNState.Focus()
            Return False
        End If
        If Me.txtNominee_SharePercentage.Text.ToString.Trim() = "" Then
            MsgBox("Please do key share percentage!")
            Me.txtNominee_SharePercentage.Focus()
            Return False
        End If
        If Len(Me.txtNominee_SharePercentage.Text.ToString.Trim() > 0) Then
            Dim TotShare As Decimal = 0
            Dim dt As New DataTable
            dt = objBusi.getDetails("MEMBER", Me.lblGUID.Text.ToString.Trim(), "", "", "", "ENS", Conn)
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0)("TOTSHARE")) Then
                    TotShare = Convert.ToDecimal(dt.Rows(0)("TOTSHARE").ToString().Trim())
                End If
            End If
            Dim sShare As Decimal
            sShare = Convert.ToDecimal(Me.txtNominee_SharePercentage.Text.Trim())
            If (sShare <> oeShare Or sShare = oeShare) Then
                TotShare = TotShare - oeShare
            End If
            TotShare += Convert.ToDecimal(Me.txtNominee_SharePercentage.Text.Trim())
            If TotShare > 100 Then
                MsgBox("Invalid share percentage!")
                Me.txtNominee_SharePercentage.Focus()
                Return False
            End If
        End If
        Return True
    End Function
    Private Sub ins_Nominee()
        Dim sRes, Relation As String
        If Not chkValidation() Then
            Exit Sub
        End If
        Relation = Me.cbRelationship.SelectedIndex
        Select Case Relation
            Case "0"
                Relation = "Spouse"
            Case "1"
                Relation = "Children"
            Case "2"
                Relation = "Relative"
            Case "3"
                Relation = "Others"
        End Select
        sRes = objBusi.INSUPSNOMINEEDETAILS("INSERT", Guid.NewGuid.ToString(), Me.lblGUID.Text.ToString.Trim(), Me.txtNominee_Title.Text.Trim(), Me.txtNominee_NRIC.Text.Trim(), Me.txtNominee_Name.Text.ToString.Trim(), Format(Me.dtpNominee_DOB.Value, "MM/dd/yyyy"), Relation, Me.txtNAdd1.Text.Trim(), Me.txtNAdd2.Text.Trim(), Me.txtNAdd3.Text.Trim(), Me.txtNAdd4.Text.Trim(), Me.txtNTown.Text.Trim(), Me.txtNState.Text.Trim(), Me.txtNPoscode.Text.Trim(), Me.txtNominee_SharePercentage.Text.Trim.Trim(), Format(Me.dtpEffectiveDate.Value, "MM/dd/yyyy"), My.Settings.Username, Conn)
        If Me.lblAdmin.Text = "Admin" Then
            Me.objBusi.aLog(Me.lblGUID.Text, "Adding New Nominee User ID : " & My.Settings.Username & " ", Conn)
        Else
            Me.objBusi.Log(Me.lblGUID.Text, "Adding New Nominee User ID : " & My.Settings.Username & " ", Conn)
            Me.objBusi.EndorsementLog(Me.lblMemberID.Text, Me.lblGUID.Text, "E", "Adding New Nominee IC New :  " & Me.txtNominee_NRIC.Text & " Name : " & Me.txtNominee_Name.Text & " Share Percentage : " & Me.txtNominee_SharePercentage.Text.ToString().Trim() & " Effective Date : " & Format(Me.dtpEffectiveDate.Value, "dd/MM/yyyy hh:mm:ss"), Now(), "", Format(Me.dtpEffectiveDate.Value, "dd/MM/yyyy hh:mm:ss"), Me.txtNominee_NRIC.Text.ToString.Trim(), "ADD NOMINEE", Conn)
        End If
        If sRes = "1" Then
            MsgBox("Successfully Inserted Nominee")
            Clear_All()
            Me.Close()
        Else
            MsgBox("Error while Inserting Nominee")
        End If
    End Sub
    Private Sub ups_Nominee()
        Dim sRes, Relation As String
        If Not chkValidation() Then
            Exit Sub
        End If
        Relation = Me.cbRelationship.SelectedIndex
        Select Case Relation
            Case "0"
                Relation = "Spouse"
            Case "1"
                Relation = "Children"
            Case "2"
                Relation = "Relative"
            Case "3"
                Relation = "Others"
        End Select
        sRes = objBusi.INSUPSNOMINEEDETAILS("UPDATE", Me.lblNomineeID.Text.ToString.Trim(), Me.lblNomineeID.Text.ToString.Trim(), Me.txtNominee_Title.Text.Trim(), Me.txtNominee_NRIC.Text.Trim(), Me.txtNominee_Name.Text.ToString.Trim(), Format(Me.dtpNominee_DOB.Value, "MM/dd/yyyy"), Relation, Me.txtNAdd1.Text.Trim(), Me.txtNAdd2.Text.Trim(), Me.txtNAdd3.Text.Trim(), Me.txtNAdd4.Text.Trim(), Me.txtNTown.Text.Trim(), Me.txtNState.Text.Trim(), Me.txtNPoscode.Text.Trim(), Me.txtNominee_SharePercentage.Text.Trim.Trim(), Format(Me.dtpEffectiveDate.Value, "MM/dd/yyyy"), My.Settings.Username, Conn)
        If Me.lblAdmin.Text = "Admin" Then
            Me.objBusi.aLog(Me.lblMemberID.Text, "Updating Nominee Details User ID : " & My.Settings.Username & " ", Conn)
        Else
            Me.objBusi.Log(Me.lblMemberID.Text, "Updating Nominee Details User ID : " & My.Settings.Username & " ", Conn)
            Me.objBusi.EndorsementLog(Me.lblMemberID.Text, Me.lblID.Text, "E", Endorsment_Changes(), Now(), "CHAGE OF NOMINEE DETAILS", Me.dtpEffectiveDate.Value, Me.txtNominee_NRIC.Text.ToString.Trim(), "CHANGE OF NOMINEE DETAILS", Conn)
        End If
        If sRes = "1" Then
            MsgBox("Successfully Updated Nominee")
            Clear_All()
            Me.Close()
        Else
            MsgBox("Error while updating Nominee")
        End If
    End Sub
    Private Sub Clear_All()

        Me.txtNAdd1.Text = ""
        Me.txtNAdd2.Text = ""
        Me.txtNAdd3.Text = ""
        Me.txtNAdd4.Text = ""
        Me.txtNTown.Text = ""
        Me.txtNState.Text = ""
        Me.txtNPoscode.Text = ""
        Me.txtNominee_Name.Text = ""
        Me.txtNominee_NRIC.Text = ""
        Me.txtNominee_SharePercentage.Text = ""
        Me.cbRelationship.SelectedIndex = 0
        Me.txtNominee_SharePercentage.Text = ""
        Me.txtNominee_Title.Text = ""
    End Sub
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Clear_All()
        Me.Close()
    End Sub
    Private Function Endorsment_Changes() As String
        Dim Title, Name, DOB, NRIC, Add1, Add2, Add3, Add4, Town, State, Poscode, Share As String
        Dim sRemarks As String = ""

        If Me.txtNominee_Title.Text.Trim <> otitle.ToString.Trim() Then
            If Len(otitle.ToString.Trim()) = 0 Then
                title = "(BLANK)"
            Else
                title = otitle.ToString.Trim()
            End If
            sRemarks = "Change of Nominee Title from: " & Title & " to " & Me.txtNominee_Title.Text.Trim & ". "
        End If


        If Me.txtNominee_Name.Text.Trim <> oName.ToString.Trim Then
            If Len(oName.ToString.Trim) = 0 Then
                Name = "(BLANK)"
            Else
                Name = oName.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Nominee Name from: " & oName & " to " & Me.txtNominee_Name.Text.Trim & ". "
        End If

        If Me.dtpNominee_DOB.Value <> oDOB.ToString.Trim Then
            If Len(oDOB.ToString.Trim) = 0 Then
                DOB = "(BLANK)"
            Else
                DOB = oDOB.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Nominee Date Of Birth from: " & DOB & " to " & Me.dtpNominee_DOB.Value & ". "
        End If

        If Me.txtNominee_NRIC.Text.Trim <> oNRIC.ToString.Trim Then
            If Len(oNRIC.ToString.Trim) = 0 Then
                NRIC = "(BLANK)"
            Else
                NRIC = oNRIC.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Nominee NRIC from: " & NRIC & " to " & Me.txtNominee_NRIC.Text.Trim & ". "
        End If

        If Me.txtNAdd1.Text.Trim <> oAdd1.ToString.Trim Then
            If Len(oAdd1.ToString.Trim) = 0 Then
                Add1 = "(BLANK)"
            Else
                Add1 = oAdd1.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Nominee Postal Address from: " & Add1 & " to " & Me.txtNAdd1.Text.Trim & ". "
        End If

        If Me.txtNAdd2.Text.Trim <> oAdd2.ToString.Trim Then
            If Len(oAdd2.ToString.Trim) = 0 Then
                Add2 = "(BLANK)"
            Else
                Add2 = oAdd2.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Nominee Postal Address2 from: " & Add2 & " to " & Me.txtNAdd2.Text.Trim & ". "
        End If

        If Me.txtNAdd3.Text.Trim <> oAdd1.ToString.Trim Then
            If Len(oAdd3.ToString.Trim) = 0 Then
                Add3 = "(BLANK)"
            Else
                Add3 = oAdd3.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Nominee Postal Address3 from: " & Add3 & " to " & Me.txtNAdd3.Text.Trim & ". "
        End If

        If Me.txtNAdd4.Text.Trim <> oAdd4.ToString.Trim Then
            If Len(oAdd4.ToString.Trim) = 0 Then
                Add4 = "(BLANK)"
            Else
                Add4 = oAdd4.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Nominee Postal Address4 from: " & Add4 & " to " & Me.txtNAdd4.Text.Trim & ". "
        End If


        If Me.txtNTown.Text.Trim <> oTown.ToString.Trim Then
            If Len(oTown.ToString.Trim) = 0 Then
                Town = "(BLANK)"
            Else
                Town = oTown.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Nominee Town from: " & Town & " to " & Me.txtNTown.Text.Trim & ". "
        End If


        If Me.txtNState.Text.Trim <> oState.ToString.Trim Then
            If Len(oState.ToString.Trim) = 0 Then
                State = "(BLANK)"
            Else
                State = oState.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Nominee State from: " & State & " to " & Me.txtNState.Text.Trim & ". "
        End If


        If Me.txtNPoscode.Text.Trim <> oPoscode.ToString.Trim Then
            If Len(oPoscode.ToString.Trim) = 0 Then
                Poscode = "(BLANK)"
            Else
                Poscode = oPoscode.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Nominee Poscode from: " & Poscode & " to " & Me.txtNPoscode.Text.Trim & ". "
        End If


        If Me.txtNominee_SharePercentage.Text.Trim <> oShare.ToString.Trim Then
            If Len(oShare.ToString.Trim) = 0 Then
                Share = "(BLANK)"
            Else
                Share = oShare.ToString.Trim
            End If
            sRemarks = sRemarks.Trim() & "Change of Nominee  Share Percentage from: " & Share & " to " & Me.txtNominee_SharePercentage.Text.Trim & ". "
        End If
        Return sRemarks
    End Function
    Private Sub cbMemberAdd_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbMemberAdd.CheckedChanged
        If Me.cbMemberAdd.Checked Then
            Me.txtNAdd1.ReadOnly = True
            Me.txtNAdd2.ReadOnly = True
            Me.txtNAdd3.ReadOnly = True
            Me.txtNAdd4.ReadOnly = True
            Me.txtNTown.ReadOnly = True
            Me.txtNState.ReadOnly = True
            Me.txtNPoscode.ReadOnly = True
            Dim dt As New DataTable
            dt = objBusi.getDetails("MEMBERDETAILS", Me.lblMemberID.Text.Trim(), "", "", "", "MEMBER", Conn)
            If dt.Rows.Count > 0 Then
                If Not IsDBNull(dt.Rows(0)("POSTAL_ADDRESS_L1")) Then
                    Me.txtNAdd1.Text = dt.Rows(0)("POSTAL_ADDRESS_L1").ToString.Trim()
                Else
                    Me.txtNAdd1.Text = ""
                End If
                If Not IsDBNull(dt.Rows(0)("POSTAL_ADDRESS_L2")) Then
                    Me.txtNAdd2.Text = dt.Rows(0)("POSTAL_ADDRESS_L2").ToString.Trim()
                Else
                    Me.txtNAdd2.Text = ""
                End If
                If Not IsDBNull(dt.Rows(0)("Add3")) Then
                    Me.txtNAdd3.Text = dt.Rows(0)("Add3").ToString.Trim()
                Else
                    Me.txtNAdd3.Text = ""
                End If
                If Not IsDBNull(dt.Rows(0)("Add4")) Then
                    Me.txtNAdd4.Text = dt.Rows(0)("Add4").ToString.Trim()
                Else
                    Me.txtNAdd4.Text = ""
                End If
                If Not IsDBNull(dt.Rows(0)("TOWN")) Then
                    Me.txtNTown.Text = dt.Rows(0)("TOWN").ToString.Trim()
                Else
                    Me.txtNTown.Text = ""
                End If
                If Not IsDBNull(dt.Rows(0)("POSTCODE")) Then
                    Me.txtNPoscode.Text = dt.Rows(0)("POSTCODE").ToString.Trim()
                Else
                    Me.txtNPoscode.Text = ""
                End If
                If Not IsDBNull(dt.Rows(0)("STATE")) Then
                    Me.txtNState.Text = dt.Rows(0)("STATE").ToString.Trim()
                Else
                    Me.txtNState.Text = ""
                End If

            End If
        Else
            Me.txtNAdd1.ReadOnly = False
            Me.txtNAdd2.ReadOnly = False
            Me.txtNAdd3.ReadOnly = False
            Me.txtNAdd4.ReadOnly = False
            Me.txtNTown.ReadOnly = False
            Me.txtNState.ReadOnly = False
            Me.txtNPoscode.ReadOnly = False
            Me.txtNAdd1.Text = ""
            Me.txtNAdd2.Text = ""
            Me.txtNTown.Text = ""
            Me.txtNState.Text = ""
            Me.txtNPoscode.Text = ""

        End If
    End Sub
    Private Sub btnNState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNState.Click
        Dim frmSearch_State As New frmSearch_Param
        frmSearch_State.lblForm_Flag.Text = "S"
        frmSearch_State.ShowDialog()
        Me.txtNState.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
    Private Sub txtNominee_SharePercentage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNominee_SharePercentage.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If Not ((KeyAscii >= System.Windows.Forms.Keys.D0 And KeyAscii <= System.Windows.Forms.Keys.D9) Or (KeyAscii = System.Windows.Forms.Keys.Back) Or (Chr(KeyAscii) Like "[ ]") Or (Chr(KeyAscii) = ".")) Then
            KeyAscii = 0
            Me.txtNominee_SharePercentage.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub txtNPoscode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNPoscode.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If Not ((KeyAscii >= System.Windows.Forms.Keys.D0 And KeyAscii <= System.Windows.Forms.Keys.D9) Or (KeyAscii = System.Windows.Forms.Keys.Back) Or (Chr(KeyAscii) Like "[ ]")) Then
            KeyAscii = 0
            Me.txtNPoscode.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If Not Len(Me.txtRemarks.Text.Trim) > 0 Then
                MsgBox("Please do key in reason for delete!")
                Me.txtRemarks.Focus()
                Exit Sub
            End If
            If MsgBox("Are you sure you want delete this Nomination?", vbYesNo, "MEMBER") = vbYes Then
                Dim sRes As String
                sRes = objBusi.Delete("MEMBER", Me.lblNomineeID.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "NOMINEE", Conn)

                If sRes = "1" Then
                    If Me.lblAdmin.Text = "Admin" Then
                        Me.objBusi.aLog(Me.lblGUID.Text.ToString().Trim(), "Deleted Nominee " & Me.txtNominee_Name.Text.Trim() & " User ID : " & My.Settings.Username & " ", Conn)
                    Else
                        Me.objBusi.Log(Me.lblGUID.Text, "Deleted Nominee " & Me.txtNominee_Name.Text.Trim() & " User ID : " & My.Settings.Username & " ", Conn)
                        Me.objBusi.EndorsementLog(Me.lblMemberID.Text, Me.lblGUID.Text, "E", "Deleted Nominee IC New :  " & Me.txtNominee_NRIC.Text & " Name : " & Me.txtNominee_Name.Text & " Share Percentage : " & Me.txtNominee_SharePercentage.Text.ToString().Trim() & " Effective Date : " & Format(Me.dtpEffectiveDate.Value, "dd/MM/yyyy hh:mm:ss") & " Remarks : " & Me.txtRemarks.Text.Trim(), Now(), "", Format(Me.dtpEffectiveDate.Value, "dd/MM/yyyy hh:mm:ss"), Me.txtNominee_NRIC.Text.ToString.Trim(), "DELETE NOMINEE", Conn)
                    End If
                    MsgBox("Successfully deleted the Nomination!")
                    Me.Close()
                Else
                    MsgBox("Error while delete Nomination, Please try again later!")
                End If
            End If
        Catch ex As Exception
            MsgBox("Server busy, Please try again later!")
        End Try
    End Sub

   
End Class