Public Class aMember
#Region "Global Veriables"
    Dim _objBusi As New Business
    Dim Conn As DbConnection = New SqlConnection
#End Region
#Region "Page Events"
    Private Sub aMember_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub aMember_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Populate_Form()
    End Sub
#End Region
#Region "Data Bind"
    Private Sub Populate_Form()
        Try
            SharedData.ReadyToHideMarquee = False
            StartMarqueeThread()

            Dim cmdSelect_Member As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
            cmdSelect_Member.CommandType = CommandType.Text
            cmdSelect_Member.CommandText = "SELECT ID, CLIENTID,  Angkasa_FileNo, Title, Full_Name, Birth_Date, IC_New, IC_Old, " & _
                                           "ArmForce_ID, Race, Marital_Status, Sex, Postal_Address_L1, Postal_Address_L2, " & _
                                           "Town, Postcode, State, Phone_Hse, Phone_Mobile, Phone_Off, Email, Height, " & _
                                           "Weight, Occupation, Department, Add3, Add4 " & _
                                           "FROM dt_Member WHERE ID = '" & Me.lblID.Text.Trim & "'"
            Dim da_Member As New SqlDataAdapter(cmdSelect_Member)

            Dim ds_MemberInfo As New DataSet


            da_Member.Fill(ds_MemberInfo, "dt_Member")
            SyncLock SharedData
                SharedData.ReadyToHideMarquee = True
            End SyncLock
            Application.DoEvents()
            If ds_MemberInfo.Tables("dt_Member").Rows.Count = 0 Then
                MsgBox("Error in Loading Data...")
                Exit Sub
            Else

                With ds_MemberInfo.Tables("dt_Member").Rows(0)

                    Me.txtMember_Title.Text = .Item("Title").ToString.Trim & " "
                    Me.txtMember_Name.Text = .Item("Full_Name").ToString.Trim & " "
                    If IsDBNull(.Item("Birth_Date")) = False Then
                        Me.dtpMember_DOB.Value = .Item("Birth_Date")
                    Else

                    End If
                    Me.txtMember_NRIC.Text = .Item("IC_New").ToString.Trim & " "
                    Me.txtMember_OldIC.Text = .Item("IC_Old").ToString.Trim & " "
                    Me.txtMember_ArmForceID.Text = .Item("ArmForce_ID").ToString.Trim & " "
                    Me.txtClientID.Text = .Item("CLIENTID").ToString.Trim & " "


                    If IsDBNull(.Item("Race")) = False Then
                        Select Case .Item("Race")
                            Case "M"
                                Me.rdiMember_Race_Malay.Checked = True
                            Case "C"
                                Me.rdiMember_Race_Chinese.Checked = True
                            Case "I"
                                Me.rdiMember_Race_Indian.Checked = True
                            Case "O"
                                Me.rdiMember_Race_Others.Checked = True
                        End Select
                    Else

                    End If

                    If IsDBNull(.Item("Marital_Status")) = False Then
                        Select Case .Item("Marital_Status")
                            Case "S"
                                Me.rdiMember_MaritalStatus_Single.Checked = True
                            Case "M"
                                Me.rdiMember_MaritalStatus_Married.Checked = True
                            Case "W"
                                Me.rdiMember_MaritalStatus_Widowed.Checked = True
                            Case "D"
                                Me.rdiMember_MaritalStatus_Divorced.Checked = True
                        End Select
                    Else

                    End If

                    If IsDBNull(.Item("Sex")) = False Then
                        If .Item("Sex") = True Then
                            Me.rdiMember_Sex_Male.Checked = True
                        Else
                            Me.rdiMember_Sex_Female.Checked = True
                        End If
                    Else

                    End If

                    Me.txtMember_AddressL1.Text = .Item("Postal_Address_L1").ToString.Trim & " "
                    Me.txtMember_AddressL2.Text = .Item("Postal_Address_L2").ToString.Trim & " "
                    Me.txtAdd3.Text = .Item("Add3").ToString.Trim & " "
                    Me.txtAdd4.Text = .Item("Add4").ToString.Trim & " "
                    Me.txtMember_City.Text = .Item("Town").ToString.Trim & " "
                    Me.txtMember_Postcode.Text = .Item("Postcode").ToString.Trim & " "
                    Me.txtMember_State.Text = .Item("State").ToString.Trim & " "
                    Me.txtMember_Phone_Hse.Text = .Item("Phone_Hse").ToString.Trim & " "
                    Me.txtMember_Mobile.Text = .Item("Phone_Mobile").ToString.Trim & " "
                    Me.txtMember_Phone_Ofc.Text = .Item("Phone_Off").ToString.Trim & " "
                    Me.txtMember_Email.Text = .Item("Email").ToString.Trim & " "
                    Me.txtMember_Height.Text = .Item("Height").ToString.Trim & " "
                    Me.txtMember_Weight.Text = .Item("Weight").ToString.Trim & " "
                    Me.txtMember_Occupation.Text = .Item("Occupation").ToString.Trim & " "
                    Me.txtMember_Department.Text = .Item("Department").ToString.Trim & " "
                End With

            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
#End Region
#Region "Click Events"
    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub btnState_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnState.Click
        Dim frmSearch_State As New frmSearch_Param

        frmSearch_State.lblForm_Flag.Text = "S"
        frmSearch_State.ShowDialog()

        Me.txtMember_State.Text = My.Computer.Clipboard.GetText()
        My.Computer.Clipboard.Clear()
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            Dim Race, M_Status, Sex As String

            If Not chkValidation() Then
                Exit Sub
            End If
            If Me.rdiMember_Race_Indian.Checked Then
                Race = "I"
            ElseIf Me.rdiMember_Race_Malay.Checked Then
                Race = "M"
            ElseIf Me.rdiMember_Race_Chinese.Checked Then
                Race = "C"
            ElseIf Me.rdiMember_Race_Others.Checked Then
                Race = "O"
            End If

            If Me.rdiMember_MaritalStatus_Single.Checked Then
                M_Status = "S"
            ElseIf Me.rdiMember_MaritalStatus_Married.Checked Then
                M_Status = "M"
            ElseIf Me.rdiMember_MaritalStatus_Divorced.Checked Then
                M_Status = "D"
            ElseIf Me.rdiMember_MaritalStatus_Widowed.Checked Then
                M_Status = "W"
            End If
            If Me.rdiMember_Sex_Male.Checked Then
                Sex = "1"
            Else
                Sex = "0"
            End If

            Dim sRes As String
            sRes = _objBusi.UpdateMemberDetails("UPS", Me.lblID.Text.ToString.Trim(), Me.txtClientID.Text.ToString.Trim(), Me.txtMember_Title.Text.Trim(), Me.txtMember_Name.Text.Trim(), Format(Me.dtpMember_DOB.Value, "MM/dd/yyyy"), Me.txtMember_NRIC.Text.Trim(), Race, M_Status, Sex, Me.txtMember_AddressL1.Text.ToString.Trim(), Me.txtMember_AddressL2.Text.ToString.Trim(), Me.txtAdd3.Text.ToString.Trim(), Me.txtAdd4.Text.ToString.Trim(), Me.txtMember_City.Text.Trim(), Me.txtMember_State.Text.Trim(), Me.txtMember_Postcode.Text.Trim(), Me.cbBankName.Text.ToString.Trim(), Me.txtBankAc.Text.ToString.Trim(), Me.txtMember_Phone_Hse.Text.Trim(), Me.txtMember_Mobile.Text.Trim(), Me.txtMember_Phone_Ofc.Text.Trim(), Me.txtMember_Email.Text.Trim(), Me.txtMember_Height.Text.Trim(), Me.txtMember_Weight.Text.Trim(), Me.txtMember_Occupation.Text.Trim(), Me.txtMember_Department.Text.Trim(), My.Settings.Username, Conn)
            _objBusi.aLog(Me.lblID.Text, "Updated Member details User Name : " & My.Settings.Username & " ", Conn)
            If sRes = "1" Then
                MsgBox("Successfully Changed the Member Details")
                Me.Close()
            Else
                MsgBox("Error while updating member/policy details!")
            End If
            Me.Close()
        Catch ex As Exception
            MsgBox("Error while Changing the Member Details")
        End Try
    End Sub
#End Region
#Region "General Functions/Subs"
    Private Function chkValidation() As Boolean
        If Me.txtMember_NRIC.Text.ToString.Trim() = "" Then
            MsgBox("IC Can't be Blank!")
            Me.txtMember_NRIC.Focus()
            Return False
        End If
        If Me.txtMember_Title.Text.ToString.Trim() = "" Then
            MsgBox("Title Can't be Blank!")
            Me.txtMember_Title.Focus()
            Return False
        End If
        If Me.txtMember_Name.Text.ToString.Trim() = "" Then
            MsgBox("Name Can't be Blank!")
            Me.txtMember_Name.Focus()
            Return False
        End If
        If Me.rdiMember_Race_Malay.Checked = False Then
            If Me.rdiMember_Race_Indian.Checked = False Then
                If Me.rdiMember_Race_Chinese.Checked = False Then
                    If Me.rdiMember_Race_Others.Checked = False Then
                        MsgBox("Please Select the Race!")
                        Me.rdiMember_Race_Malay.Focus()
                        Return False
                    End If
                End If
            End If
        End If
        If Me.rdiMember_MaritalStatus_Single.Checked = False Then
            If Me.rdiMember_MaritalStatus_Married.Checked = False Then
                If Me.rdiMember_MaritalStatus_Widowed.Checked = False Then
                    If Me.rdiMember_MaritalStatus_Divorced.Checked = False Then
                        MsgBox("Please Select the Marital Status!")
                        Me.rdiMember_MaritalStatus_Single.Focus()
                        Return False
                    End If
                End If
            End If
        End If
        If Me.rdiMember_Sex_Male.Checked = False Then
            If Me.rdiMember_Sex_Female.Checked = False Then
                MsgBox("Please Select the Sex!")
                Me.rdiMember_Sex_Male.Focus()
                Return False
            End If
        End If
        If Me.txtMember_AddressL1.Text.ToString.Trim() = "" Then
            MsgBox("Address Can't be Blank!")
            Me.txtMember_AddressL1.Focus()
            Return False
        End If
        If Me.txtMember_Postcode.Text.ToString.Trim() = "" Then
            MsgBox("Postcode Can't be Blank!")
            Me.txtMember_Postcode.Focus()
            Return False
        End If
        If Me.txtMember_City.Text.ToString.Trim() = "" Then
            MsgBox("Town Can't be Blank!")
            Me.txtMember_City.Focus()
            Return False
        End If
        If Me.txtMember_State.Text.ToString.Trim() = "" Then
            MsgBox("State Can't be Blank!")
            Me.txtMember_State.Focus()
            Return False
        End If
        Return True
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