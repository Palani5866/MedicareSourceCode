Imports System.IO
Public Class vDocs
    Dim Conn As DbConnection = New SqlConnection
    Dim _ObjBusi As New Business

    Private Sub vDocs_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub vDocs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        dt = _ObjBusi.getDetails_VIII("SFNPDOCS", Me.lblP1.Text.ToString.Trim(), "", "", "", "", "", "", "", "", "", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvDocView
                .DataSource = dt

            End With
        Else
            Me.dgvDocView.DataSource = dt
            MsgBox("No record found")
        End If
    End Sub
    Private Sub dgvDocView_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDocView.CellContentClick
        With Me.dgvDocView
            If e.ColumnIndex = 0 Then
                If .Rows.Count = 0 Then
                    Exit Sub
                End If
                downLoadFile(.Rows(e.RowIndex).Cells(1).Value.ToString().Trim(), "filename", "extenstion")
            End If
        End With
    End Sub
    Private Sub downLoadFile(ByVal iFileId As String, ByVal sFileName As String, ByVal sFileExtension As String)
        Try
            Dim dt As New DataTable
            dt = _ObjBusi.getDetails_VI("VSFR", iFileId, "", "", "", "", "", "", "", "", "", Conn)
            Dim strSql As String
            strSql = "Select DOC_DATA from dt_Shortfall_Account WHERE Id='" & iFileId & "'"
            Dim sqlCmd As New SqlCommand(strSql, Conn)
            Dim dbbyte As Byte() = DirectCast(sqlCmd.ExecuteScalar(), Byte())
            Dim filepath As String = Application.StartupPath & "\Report\Letters\" & dt.Rows(0)("DOC_NAME").ToString()
            Dim FS As FileStream
            FS = New FileStream(filepath, System.IO.FileMode.Create)
            FS.Write(dbbyte, 0, dbbyte.Length)
            FS.Close()
            Dim Proc As Process
            Proc = New Process()
            Proc.StartInfo.FileName = filepath
            Proc.Start()
        Catch ex As Exception
            MsgBox("No record found!")
        End Try
    End Sub
End Class