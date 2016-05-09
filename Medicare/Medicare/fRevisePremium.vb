Public Class fRevisePremium
#Region "Global Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub fRevisePremium_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fRevisePremium_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
#End Region
#Region "Data Bind"
    Private Sub BINDDATA()
        Dim dt As New DataTable
        dt = _objBusi.fgetRevisePremiumDetails("PREMIUM", "", "", "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvPremiumDetails
                .DataSource = dt
                .Columns(0).Visible = False
            End With
        Else
            MsgBox("No record found")
            Me.dgvPremiumDetails.DataSource = dt
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim sRes As String
        If Me.txtRPremium.Text.ToString.Trim() = "" Then
            MsgBox("Required revised premium!")
            Me.txtRPremium.Focus()
            Exit Sub
        End If
        If Me.txtRemarks.Text.ToString.Trim() = "" Then
            MsgBox("Required remarks for revised premium!")
            Me.txtRPremium.Focus()
            Exit Sub
        End If
        Try
            sRes = _objBusi.fRevisePremium(Me.lblDCode.Text.Trim(), Me.txtPlanCode.Text.Trim(), Me.txtPlanType.Text.Trim(), Me.txtPremium.Text.Trim.Trim(), Me.txtRPremium.Text.Trim(), Format(Me.dtpREDate.Value, "MM/dd/yyyy"), Me.txtRemarks.Text.Trim(), My.Settings.Username.Trim(), Conn)
            If sRes = "1" Then
                MsgBox("Successfully revise the premium!")
                Me.btnSubmit.Enabled = False
                fClear()
                BINDDATA()
            Else
                MsgBox("Error while revising the premium, Please check with your admin!")
            End If
        Catch ex As Exception
            MsgBox("Currently our server busy or error while revising the premium, Please check with your admin!")
        End Try
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        fClear()
    End Sub
    Private Sub dgvPremiumDetails_CellDoubleClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPremiumDetails.CellDoubleClick
        With Me.dgvPremiumDetails
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            If Me.dgvPremiumDetails.SelectedRows.Count > 0 Then
                Me.lblDCode.Text = Me.dgvPremiumDetails.SelectedRows(0).Cells(0).Value.ToString.Trim
                Me.txtPlanCode.Text = Me.dgvPremiumDetails.SelectedRows(0).Cells(1).Value.ToString.Trim
                Me.txtPlanType.Text = Me.dgvPremiumDetails.SelectedRows(0).Cells(2).Value.ToString.Trim
                Me.txtPremium.Text = Me.dgvPremiumDetails.SelectedRows(0).Cells(3).Value.ToString.Trim
                Me.btnSubmit.Enabled = True
                Me.gbRevisePremium.Visible = True
            Else
                MsgBox("Please do select row for premium change!")
            End If
        End With

    End Sub
#End Region
#Region "Other Events"
    Private Sub fClear()
        Me.lblDCode.Text = ""
        Me.txtPlanCode.Text = ""
        Me.txtPlanType.Text = ""
        Me.txtPremium.Text = ""
        Me.txtRPremium.Text = ""
        Me.txtRemarks.Text = ""
        Me.gbRevisePremium.Visible = False
    End Sub
#End Region
#Region "Key Press Events"
    Private Sub txtRPremium_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRPremium.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        If Not ((KeyAscii >= System.Windows.Forms.Keys.D0 And KeyAscii <= System.Windows.Forms.Keys.D9) Or (KeyAscii = System.Windows.Forms.Keys.Back) Or Chr(KeyAscii) = "." Or (Chr(KeyAscii) Like "[ ]") Or KeyAscii = "45") Then
            KeyAscii = 0
            Me.txtRPremium.Focus()
        End If
        If KeyAscii = 0 Then
            e.Handled = True
        End If

        If txtRPremium.Text.IndexOf(".") >= 0 And e.KeyChar = "." Then
            e.Handled = True
        End If

        If txtRPremium.Text.IndexOf(".") > 0 Then
            If txtRPremium.SelectionStart > txtRPremium.Text.IndexOf(".") Then
                If txtRPremium.Text.Length - txtRPremium.Text.IndexOf(".") = 3 Then
                    e.Handled = True
                End If
            End If
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