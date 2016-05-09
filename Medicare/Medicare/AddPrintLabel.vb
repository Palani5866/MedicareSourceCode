Public Class AddPrintLabel
#Region "Global Veriables"
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub AddPrintLabel_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub AddPrintLabel_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub tsReport_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsReport_Go.Click
        If Len(Me.tsReport_txtDeductionCode_From.Text.Trim) = 0 Then
            MsgBox("Please do key in the Account Code (From).")
            Me.tsReport_txtDeductionCode_From.Focus()
            Exit Sub
        End If
        Dim sCodes As String
        sCodes = Me.tsReport_txtDeductionCode_From.Text.Trim()
        PrintLetters.Print_Letters("AddLabelPrint.rpt", sCodes, "PRINTADDLABEL")
    End Sub
#End Region
End Class