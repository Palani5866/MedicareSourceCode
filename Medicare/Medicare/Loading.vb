Public Class Loading
    Public NewWidth As Integer
    Public NewHeight As Integer

    Public ReadOnly Property Marquee() As ProgressBar
        Get
            Return ProgressBar1
        End Get
    End Property
    Private Sub frmBusy_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.Location = New Point((Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2, (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2)
        Catch
        End Try
    End Sub
End Class