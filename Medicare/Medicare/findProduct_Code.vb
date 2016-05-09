Public Class findProduct_Code
#Region "General Veriable"
    Dim Conn As DbConnection = New SqlConnection()
    Dim _objBusi As New Business
#End Region
#Region "Page Events"
    Private Sub findProduct_Code_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub findProduct_Code_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        getProductDetails()
    End Sub
#End Region
#Region "Data Bind"
    Private Sub getProductDetails()
        Dim dt As New DataTable
        dt = _objBusi.getDetails_I("PRODUCT", Me.lblREF1.Text.Trim(), "", "", "", "", "", "", "", "", "CHANGEPLAN", Conn)
        If dt.Rows.Count > 0 Then
            With Me.dgvProductDetails
                .DataSource = dt
                .Columns(0).HeaderText = "Product Code"
                .Columns(1).HeaderText = "Description"
                .Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                .Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            End With
        End If
    End Sub
#End Region
#Region "Click Events"
    Private Sub dgvProductDetails_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProductDetails.CellDoubleClick
        With Me.dgvProductDetails
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            If Me.dgvProductDetails.SelectedRows.Count > 0 Then
                Clipboard.SetDataObject(Me.dgvProductDetails.SelectedRows(0).Cells(0).Value.ToString.Trim())
                Me.Close()
            End If
        End With
    End Sub
#End Region
    
End Class