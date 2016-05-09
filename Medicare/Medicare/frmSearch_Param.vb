Public Class frmSearch_Param
#Region "Global Veriables"
    Dim Conn As DbConnection = New SqlConnection
    Dim objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub frmSearch_Param_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub frmSearch_Param_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Me.SplitContainer1.Panel1Collapsed = True
        Me.SplitContainer2.Panel2Collapsed = True

        Select Case Me.lblForm_Flag.Text
            Case "T"
                Populate_Title()
            Case "S"
                Populate_State()
            Case "P"
                Populate_Plan()
            Case "P2"

            Case "$"
                Populate_PaymentMethod()
            Case "A"

            Case "D"
                Populate_DeclineReason()
            Case "E"
                Populate_ExclusionClause()
            Case "SC"
                Populate_Dependents()
            Case Else
                MsgBox("Error in populating grid")
        End Select
    End Sub
#End Region
#Region "Data Bind"
    Private Sub Populate_Title()
        Me.cmbFind_Para.Enabled = False
        Me.txtFind_String.Enabled = False
        Me.btnFind.Enabled = False

        Dim cmdSearch_Parameter As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSearch_Parameter.CommandType = CommandType.Text
        cmdSearch_Parameter.CommandText = "SELECT Salutation FROM dt_Title ORDER BY Salutation"

        '##Declare dataset for Table: dt_Title
        Dim ds_Search_Param As New DataSet

        '##Create new data adapter: da_Title
        Dim da_Title As New SqlDataAdapter(cmdSearch_Parameter)

        '##Fill dataset with records from Table: dt_Title
        da_Title.Fill(ds_Search_Param, "dt_Title")

        If ds_Search_Param.Tables(0).Rows.Count > 0 Then
            Me.SplitContainer2.Panel2Collapsed = False

            With Me.dgvFind_Result
                .DataSource = ds_Search_Param
                .DataMember = "dt_Title"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        End If
    End Sub
    Private Sub Populate_State()
        Me.cmbFind_Para.Enabled = False
        Me.txtFind_String.Enabled = False
        Me.btnFind.Enabled = False

        Dim cmdSearch_Parameter As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSearch_Parameter.CommandType = CommandType.Text
        cmdSearch_Parameter.CommandText = "SELECT State FROM dt_State ORDER BY State"

        '##Declare dataset for Table: dt_State
        Dim ds_Search_Param As New DataSet

        '##Create new data adapter: da_State
        Dim da_State As New SqlDataAdapter(cmdSearch_Parameter)

        '##Fill dataset with records from Table: dt_State
        da_State.Fill(ds_Search_Param, "dt_State")

        If ds_Search_Param.Tables(0).Rows.Count > 0 Then
            Me.SplitContainer2.Panel2Collapsed = False

            With Me.dgvFind_Result
                .DataSource = ds_Search_Param
                .DataMember = "dt_State"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        End If
    End Sub
    Private Sub Populate_Plan()
        Me.cmbFind_Para.Enabled = False
        Me.txtFind_String.Enabled = False
        Me.btnFind.Enabled = False

        Dim cmdSearch_Parameter As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSearch_Parameter.CommandType = CommandType.Text
        cmdSearch_Parameter.CommandText = "SELECT Plan_Code, Plan_Description FROM dt_Plan ORDER BY Plan_Code"

        '##Declare dataset for Table: dt_Plan
        Dim ds_Search_Param As New DataSet

        '##Create new data adapter: da_Plan
        Dim da_Plan As New SqlDataAdapter(cmdSearch_Parameter)

        '##Fill dataset with records from Table: dt_Plan
        da_Plan.Fill(ds_Search_Param, "dt_Plan")

        If ds_Search_Param.Tables(0).Rows.Count > 0 Then
            Me.SplitContainer2.Panel2Collapsed = False

            With Me.dgvFind_Result
                .DataSource = ds_Search_Param
                .DataMember = "dt_Plan"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        End If
    End Sub
    Private Sub Populate_PaymentMethod()
        Me.cmbFind_Para.Enabled = False
        Me.txtFind_String.Enabled = False
        Me.btnFind.Enabled = False

        Dim cmdSearch_Parameter As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSearch_Parameter.CommandType = CommandType.Text

        If Me.lblPayment_Frequency.Text = "Yearly" Then
            cmdSearch_Parameter.CommandText = "SELECT Payment_Method FROM sys_PaymentMethod " & _
                                              "WHERE Payment_Yearly = 'True' " & _
                                              "ORDER BY Payment_Method"
        ElseIf Me.lblPayment_Frequency.Text = "HalfYearly" Then
            cmdSearch_Parameter.CommandText = "SELECT Payment_Method FROM sys_PaymentMethod " & _
                                                          "WHERE Payment_Half_Yearly = 'True' " & _
                                                          "ORDER BY Payment_Method"
        ElseIf Me.lblPayment_Frequency.Text = "Quarterly" Then
            cmdSearch_Parameter.CommandText = "SELECT Payment_Method FROM sys_PaymentMethod " & _
                                                          "WHERE Payment_Quarterly = 'True' " & _
                                                          "ORDER BY Payment_Method"
        ElseIf Me.lblPayment_Frequency.Text = "Monthly" Then
            cmdSearch_Parameter.CommandText = "SELECT Payment_Method FROM sys_PaymentMethod " & _
                                              "WHERE Payment_Monthly = 'True' " & _
                                              "ORDER BY Payment_Method"
        End If

        '##Declare dataset for Table: sys_PaymentMethod
        Dim ds_Search_Param As New DataSet

        '##Create new data adapter: da_PaymentMethod
        Dim da_PaymentMethod As New SqlDataAdapter(cmdSearch_Parameter)

        '##Fill dataset with records from Table: sys_PaymentMethod
        da_PaymentMethod.Fill(ds_Search_Param, "sys_PaymentMethod")

        If ds_Search_Param.Tables(0).Rows.Count > 0 Then
            Me.SplitContainer2.Panel2Collapsed = False

            With Me.dgvFind_Result
                .DataSource = ds_Search_Param
                .DataMember = "sys_PaymentMethod"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        End If
    End Sub
    Private Sub Populate_DeclineReason()
        Me.cmbFind_Para.Enabled = False
        Me.txtFind_String.Enabled = False
        Me.btnFind.Enabled = False

        Dim cmdSearch_Parameter As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSearch_Parameter.CommandType = CommandType.Text
        cmdSearch_Parameter.CommandText = "SELECT Decline_Reason FROM dt_Application_Decline_Reason ORDER BY Decline_Reason"

        '##Declare dataset for Table: dt_Application_Decline_Reason
        Dim ds_Search_Param As New DataSet

        '##Create new data adapter: da_Decline_Reason
        Dim da_Decline_Reason As New SqlDataAdapter(cmdSearch_Parameter)

        '##Fill dataset with records from Table: dt_Application_Decline_Reason
        da_Decline_Reason.Fill(ds_Search_Param, "dt_Application_Decline_Reason")

        If ds_Search_Param.Tables(0).Rows.Count > 0 Then
            Me.SplitContainer2.Panel2Collapsed = False

            With Me.dgvFind_Result
                .DataSource = ds_Search_Param
                .DataMember = "dt_Application_Decline_Reason"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        End If
    End Sub
    Private Sub Populate_ExclusionClause()
        Me.cmbFind_Para.Enabled = False
        Me.txtFind_String.Enabled = False
        Me.btnFind.Enabled = False
        Dim cmdSearch_Parameter As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSearch_Parameter.CommandType = CommandType.Text
        cmdSearch_Parameter.CommandText = "SELECT ExclusionClause_Code, ExclusionClause_Header, ExclusionClause_Footer FROM dt_Underwriting_ExclusionClause " & _
                                          "ORDER BY ExclusionClause_Code"


        Dim ds_Search_Param As New DataSet

        Dim da_ExclusionClause As New SqlDataAdapter(cmdSearch_Parameter)

        da_ExclusionClause.Fill(ds_Search_Param, "dt_Underwriting_ExclusionClause")
        If ds_Search_Param.Tables(0).Rows.Count > 0 Then
            Me.SplitContainer2.Panel2Collapsed = False
            With Me.dgvFind_Result
                .DataSource = ds_Search_Param
                .DataMember = "dt_Underwriting_ExclusionClause"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        End If
    End Sub
    Private Sub Populate_Dependents()
        Me.cmbFind_Para.Enabled = False
        Me.txtFind_String.Enabled = False
        Me.btnFind.Enabled = False
        If Me.dgvFind_Result.Rows.Count > 0 Then
            Me.SplitContainer2.Panel2Collapsed = False
            Me.dgvFind_Result.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            Me.dgvFind_Result.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        My.Computer.Clipboard.Clear()
        If Me.dgvFind_Result.SelectedRows.Count > 0 Then
            My.Computer.Clipboard.SetText(Me.dgvFind_Result.SelectedRows(0).Cells(0).Value.ToString.Trim())
            Me.Close()
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub btnFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFind.Click
    End Sub
#End Region
#Region "General Functions/Subs"
    Public Function SwapClipboardHtmlText( _
            ByVal replacementHtmlText As String) As String
        Dim returnHtmlText As String = Nothing
        If (Clipboard.ContainsText(TextDataFormat.Text)) Then
            returnHtmlText = Clipboard.GetText(TextDataFormat.Text)
            My.Computer.Clipboard.SetText(replacementHtmlText, TextDataFormat.Text)
        End If
        Return returnHtmlText
    End Function
#End Region
End Class