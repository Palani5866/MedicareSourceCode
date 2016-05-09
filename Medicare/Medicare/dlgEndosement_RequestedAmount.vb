Imports System.Windows.Forms
Imports System.IO
Public Class dlgEndosement_RequestedAmount
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Dim MID As String
#End Region
#Region "Page Events"
    Private Sub dlgEndosement_RequestedAmount_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub dlgEndosement_RequestedAmount_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.dtpEffective_Date.Enabled = False
        Me.btnBrowse.Enabled = False
        Me.btnClear.Enabled = False
        Me.btnUpload.Enabled = False
        If Not (My.Settings.Username = "admin" Or My.Settings.Username = "SRI") Then
            Me.dtpEffective_Date.MinDate = DateTime.Now()
        End If
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
            Me.txtL2_Plan_Code.Clear()
            Me.txtRequested_Amount_Old.Clear()
            Me.txtPolicy_EffectiveDate_Old.Clear()
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

            .Columns(0).Visible = False 'ID

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
        Me.txtL2_Plan_Code.Clear()
        Me.txtRequested_Amount_Old.Clear()
        Me.txtPolicy_EffectiveDate_Old.Clear()
        Me.txtRequested_Amount_New.Clear()
        If e.RowIndex = -1 Then
            Exit Sub
        Else
            'If Me.dgvPolicies.Rows(e.RowIndex).Cells(9).Value.ToString.Trim = "" Then
            With Me.dgvPolicies.Rows(e.RowIndex)


                Me.lblMemberPolicy_ID.Text = .Cells(0).Value.ToString.Trim
                Me.txtFileNo.Text = .Cells(1).Value.ToString.Trim
                Me.txtName.Text = .Cells(2).Value.ToString.Trim
                Me.txtNRIC.Text = .Cells(3).Value.ToString.Trim
                Me.txtL2_Plan_Code.Text = .Cells(4).Value.ToString.Trim
                If Len(.Cells(5).Value.ToString.Trim) > 0 Then
                    If IsNumeric(.Cells(5).Value) = True Then
                        Me.txtRequested_Amount_Old.Text = Format(.Cells(5).Value, "#,##0.00")
                    End If
                End If
                If Len(.Cells(8).Value.ToString.Trim) > 0 Then
                    Me.txtPolicy_EffectiveDate_Old.Text = Format(.Cells(8).Value, "dd/MM/yyyy")
                End If
                getPremium()
                Me.dtpEffective_Date.Enabled = True
                Me.OK_Button.Enabled = True
                Me.btnBrowse.Enabled = True
                Me.btnClear.Enabled = True
                Me.btnUpload.Enabled = True
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
                        Me.lblMemberPolicy_ID.Text = "GUID"
                        Me.txtFileNo.Clear()
                        Me.txtName.Clear()
                        Me.txtNRIC.Clear()
                        Me.txtL2_Plan_Code.Clear()
                        Me.txtRequested_Amount_Old.Clear()
                        Me.txtPolicy_EffectiveDate_Old.Clear()
                    Else
                        MsgBox("Error in endorsing this record.")
                        Me.OK_Button.Enabled = True
                    End If
                Case 7
                    Exit Sub
            End Select

        End If
    End Sub
#End Region
#Region "Endorse"
    Private Function Endorse_Changes() As Boolean
        Dim cmdSelect_MemberPolicy As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_MemberPolicy.CommandType = CommandType.Text
        cmdSelect_MemberPolicy.CommandText = "SELECT * FROM dt_Member_Policy " & _
                                             "WHERE ID = '" & Me.lblMemberPolicy_ID.Text.Trim & "'"
        Dim da_MemberPolicy As New SqlDataAdapter(cmdSelect_MemberPolicy)

        Dim cmdUpdate_MemberPolicy As SqlCommandBuilder
        cmdUpdate_MemberPolicy = New SqlCommandBuilder(da_MemberPolicy)


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


        Dim ds_Endorsement As New DataSet


        Try
            da_MemberPolicy.Fill(ds_Endorsement, "dt_Member_Policy")
            da_MemberLog.Fill(ds_Endorsement, "log_Member")
            da_Member_Endorsement.Fill(ds_Endorsement, "dt_Member_Endorsement")


            With ds_Endorsement.Tables("dt_Member_Policy").Rows(0)
                .Item("Deduction_Amount") = Me.txtRequested_Amount_New.Text
                .Item("Last_Modified_By") = My.Settings.Username.Trim
                .Item("Last_Modified_On") = Now()
            End With

            da_MemberPolicy.Update(ds_Endorsement, "dt_Member_Policy")
            Dim varID As String
            varID = Guid.NewGuid.ToString.Trim()
            _objBusi.InsUpsPremiumHistory("CHANGEPREMIUM", varID, Me.lblMemberPolicy_ID.Text.Trim, Format(Me.dtpEffective_Date.Value, "MM/dd/yyyy"), "", Me.txtRequested_Amount_New.Text, Me.txtRequested_Amount_Old.Text.Trim(), Me.txtRemark.Text.ToString.Trim(), My.Settings.Username, Conn)
            _objBusi.InsUpsPolicyPremiumHistory("CHANGEPREMIUM", Me.lblMemberPolicy_ID.Text.ToString.Trim(), Me.txtRequested_Amount_New.Text, Format(Me.dtpEffective_Date.Value, "MM/dd/yyyy"), "", Me.txtRemark.Text.ToString.Trim(), My.Settings.Username, Conn)


            Dim dr_MemberLog As DataRow
            dr_MemberLog = ds_Endorsement.Tables("log_Member").NewRow

            With dr_MemberLog
                .Item("Member_Policy_ID") = Me.lblMemberPolicy_ID.Text.Trim
                .Item("Log_Date") = Now()
                .Item("Activity_Detail") = "Change of Requested/Deduction Amount."
                .Item("Username") = My.Settings.Username.Trim
                .Item("Created_By") = My.Settings.Username.Trim
                .Item("Created_On") = Now()
            End With
            ds_Endorsement.Tables("log_Member").Rows.Add(dr_MemberLog)
            da_MemberLog.Update(ds_Endorsement, "log_Member")

            Dim dr_Member_Endorsement_New As DataRow
            dr_Member_Endorsement_New = ds_Endorsement.Tables("dt_Member_Endorsement").NewRow

            With dr_Member_Endorsement_New
                .Item("ID") = Guid.NewGuid.ToString()
                .Item("Member_ID") = ds_Endorsement.Tables("dt_Member_Policy").Rows(0).Item("Member_ID").ToString
                .Item("Member_Policy_ID") = Me.lblMemberPolicy_ID.Text.Trim
                .Item("Log_Date") = Now()
                .Item("Endorsement_Type") = "E"
                .Item("Endorsement_Detail") = "Change of Requested/Deduction Amount From " & Me.txtRequested_Amount_Old.Text.Trim() & " to " & Me.txtRequested_Amount_New.Text.Trim() & ". "
                .Item("Request_Date") = Me.dtpRequestedDate.Value
                .Item("Remark") = Me.txtRemark.Text.ToString.Trim
                .Item("TRANS_TYPE") = "CHANGE OF PREMIUM"
                .Item("Username") = My.Settings.Username.Trim
                .Item("Created_By") = My.Settings.Username.Trim
                .Item("Created_On") = Now()
                .Item("Effective_Date") = dtpEffective_Date.Value
            End With
            ds_Endorsement.Tables("dt_Member_Endorsement").Rows.Add(dr_Member_Endorsement_New)
            da_Member_Endorsement.Update(ds_Endorsement, "dt_Member_Endorsement")
            Return True
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return False
        End Try
    End Function
#End Region
#Region "General Functions/Subs"
    Private Function Verify_Endorsement_Details() As Boolean
        If Me.txtRequested_Amount_New.Text.Trim() = 0 Then
            MsgBox("Invalid Premium! Please check the Member/Dependents/Effective Date before revise!")
            Return False
        End If
        If Me.txtRequested_Amount_Old.Text.Trim() = Me.txtRequested_Amount_New.Text.Trim() Then
            MsgBox("Invalid Premium! Please check the Member/Dependents/Effective Date before revise!")
            Return False
        End If
        If Len(Me.txtRequested_Amount_New.Text.Trim) = 0 Then
            MsgBox("Please do key in the new Premium/Requested Amount.")
            Me.txtRequested_Amount_New.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub getPremium()
        Dim dt As New DataTable
        dt = _objBusi.fgetPolicyPremium(Me.lblMemberPolicy_ID.Text.ToString.Trim(), Format(Me.dtpEffective_Date.Value, "MM/dd/yyyy"), Conn)
        If dt.Rows.Count > 0 Then
            If FormatNumber(dt.Rows(0)(0).ToString.Trim(), 2) = 0 Then
                MsgBox("We are sorry! We can't find any premium for this Member! Please Check DOB/Effective Date of the Member or Contact administrator!")
                Me.txtRequested_Amount_New.Text = FormatNumber(dt.Rows(0)(0).ToString.Trim(), 2)
            Else
                Me.txtRequested_Amount_New.Text = FormatNumber(dt.Rows(0)(0).ToString.Trim(), 2)
            End If
        Else
            Me.txtRequested_Amount_New.Text = "0.00"
            MsgBox("We are sorry we can't find any premium for this Member! Please Check DOB/Effective Date of the Member or Contact administrator!")
        End If
    End Sub
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
        openFileDialog.Filter = "pdf files (*.pdf)|*.pdf|xls files (*.xls)|*.xls|jpg files (*.jpg)|*.jpg|doc files (*.doc)|*.doc|text files (*.text)|*.txt"
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
#Region "Change Events"
    Private Sub dtpEffective_Date_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpEffective_Date.ValueChanged
        If Not Me.lblMemberPolicy_ID.Text.ToString.Trim() = "GUID" Then
            getPremium()
        End If
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
