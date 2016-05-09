Public Class fVerifiedProposers
#Region "Global Veriable"
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub fVerifiedProposers_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fVerifiedProposers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        popCB()
    End Sub
#End Region
#Region "Click Events"
    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim P2S As New grdProposer2Submit
        P2S.lblParam.Text = Me.cbPlanCode.Text.Trim()
        P2S.Show()
    End Sub
#End Region
#Region "Data Bind"
    Private Sub popCB()
        Dim dt As New DataTable
        dt = _objBusi.getDetails("VP", "", "", "", "", "", Conn)
        Me.cbPlanCode.DataSource = dt
        Me.cbPlanCode.DisplayMember = "PLAN_CODE"
        Me.cbPlanCode.ValueMember = "PLAN_CODE"
    End Sub
#End Region
End Class