Public Class grdBorang2_79
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Private Sub grdBorang2_79_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub

    Private Sub grdBorang2_79_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn

        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        Populate_Grid()
    End Sub
    Private Sub Populate_Grid()
        Dim cmdSelect_Monthly_SuspendAccount As SqlCommand = CType(Conn.CreateCommand(), SqlCommand)
        cmdSelect_Monthly_SuspendAccount.CommandType = CommandType.Text
        cmdSelect_Monthly_SuspendAccount.CommandText = "SELECT * FROM vi_Monthly_SuspendAccount where status is null " & _
                                                       "ORDER BY No_Kad_Pengenalan, Angkasa_Kod_Potongan, Angkasa_Bulan_Potongan"
        Dim da_Monthly_SuspendAccount As New SqlDataAdapter(cmdSelect_Monthly_SuspendAccount)
        Dim ds_Monthly_SuspendAccount As New DataSet
        da_Monthly_SuspendAccount.Fill(ds_Monthly_SuspendAccount, "vi_Monthly_SuspendAccount")

        With Me.dgvForm
            .DataSource = ds_Monthly_SuspendAccount
            .DataMember = "vi_Monthly_SuspendAccount"

            .Columns(0).HeaderText = "No Kad Pengenalan"
            .Columns(1).HeaderText = "No Keahlian"
            .Columns(2).HeaderText = "Bulan Potongan"
            .Columns(3).HeaderText = "Kod Potongan"
            .Columns(4).HeaderText = "Jumlah Potongan"
            .Columns(5).HeaderText = "Nama Ahli"
            .Columns(6).HeaderText = "Batch No"
            .Columns(7).HeaderText = "Receiving Month"
        End With
    End Sub
    Private Sub tsbXport2Xcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbXport2Xcel.Click
        XPort2Xcel()
    End Sub
    Private Sub XPort2Xcel()
        If Me.dgvForm.Rows.Count > 0 Then
            MsgBox("Starting the export process...", MsgBoxStyle.Information)
            Dim xApp As New Microsoft.Office.Interop.Excel.Application
            Dim xWB As Microsoft.Office.Interop.Excel.Workbook
            xWB = xApp.Workbooks.Add
            Dim xWName As String = ""

            xWB.Worksheets.Add()
            xWName = "Sheet" & xWB.Worksheets.Count.ToString.Trim
            
            With xWB.Worksheets(xWName)
                .Cells(1, 1) = "Borang 2/79 List"

                .Cells(3, 1) = "NO"
                .Cells(3, 2) = "NO KAD PENGENALAN"
                .Cells(3, 3) = "NO KEAHLIAN"
                .Cells(3, 4) = "BULAN POTONGAN"
                .Cells(3, 5) = "KOD POTONGAN"
                .Cells(3, 6) = "JUMLAH POTONGAN"
                .Cells(3, 7) = "NAMA AHLI"
                .Cells(3, 8) = "BATCH NO"
                .Cells(3, 9) = "RECEIVING MONTH"
                .Cells(3, 10) = "REQUESTED AMOUNT"
                .Cells(3, 11) = "EFFECTIVE DATE"
                .Cells(3, 12) = "CANCELLATION DATE"
                .Cells(3, 13) = "REMARKS"


                Dim xRowCount As Integer = 4
                Dim iCount As Integer = 0
                Do While iCount < Me.dgvForm.RowCount
                    Dim dt As New DataTable
                    dt = _objBusi.getDetails_I("BORANG279", Me.dgvForm.Rows(iCount).Cells(0).Value.ToString.Trim, Me.dgvForm.Rows(iCount).Cells(3).Value.ToString.Trim, "", "", "", "", "", "", "", "", Conn)

                    .Cells(xRowCount, 1) = "'" & (xRowCount - 3).ToString.Trim
                    .Cells(xRowCount, 2) = "'" & Me.dgvForm.Rows(iCount).Cells(0).Value.ToString.Trim
                    .Cells(xRowCount, 3) = "'" & Me.dgvForm.Rows(iCount).Cells(1).Value.ToString.Trim
                    .Cells(xRowCount, 4) = "'" & Me.dgvForm.Rows(iCount).Cells(2).Value.ToString.Trim
                    .Cells(xRowCount, 5) = "'" & Me.dgvForm.Rows(iCount).Cells(3).Value.ToString.Trim
                    .Cells(xRowCount, 6) = "'" & Me.dgvForm.Rows(iCount).Cells(4).Value.ToString.Trim
                    .Cells(xRowCount, 7) = "'" & Me.dgvForm.Rows(iCount).Cells(5).Value.ToString.Trim
                    .Cells(xRowCount, 8) = "'" & Me.dgvForm.Rows(iCount).Cells(6).Value.ToString.Trim
                    .Cells(xRowCount, 9) = "'" & Me.dgvForm.Rows(iCount).Cells(7).Value.ToString.Trim
                    If dt.Rows.Count > 0 Then
                        .Cells(xRowCount, 10) = "'" & dt.Rows(0)("deduction_amount")
                        .Cells(xRowCount, 11) = "'" & dt.Rows(0)("effective_date")
                        .Cells(xRowCount, 12) = "'" & dt.Rows(0)("cancellation_date")
                    Else
                        .Cells(xRowCount, 13) = "Wrong Deduction Code or No Record found"
                    End If
                    xRowCount += 1
                    iCount += 1
                Loop
            End With
            MsgBox("Exporting records to REPORT: BORANG 2/79 LIST")
            xApp.Visible = True
        End If
    End Sub
    Private Sub dgvForm_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvForm.CellDoubleClick
        With Me.dgvForm
            If .Rows.Count = 0 Then
                Exit Sub
            End If
            Dim dlg_Borang2_79 As New dlgBorang2_79
            With dlg_Borang2_79
                .txtNRIC.Text = Me.dgvForm.Rows(e.RowIndex).Cells(0).Value.ToString.Trim
                .txtAngkasa_FileNo.Text = Me.dgvForm.Rows(e.RowIndex).Cells(1).Value.ToString.Trim
                .txtDeduction_Month.Text = Me.dgvForm.Rows(e.RowIndex).Cells(2).Value.ToString.Trim
                .txtDeduction_Code.Text = Me.dgvForm.Rows(e.RowIndex).Cells(3).Value.ToString.Trim
                .lblDeduction_Code_OldValue.Text = Me.dgvForm.Rows(e.RowIndex).Cells(3).Value.ToString.Trim
                .txtDeduction_Amount.Text = Me.dgvForm.Rows(e.RowIndex).Cells(4).Value.ToString
                .txtName.Text = Me.dgvForm.Rows(e.RowIndex).Cells(5).Value.ToString.Trim
                .txtBatch_No.Text = Me.dgvForm.Rows(e.RowIndex).Cells(6).Value.ToString.Trim
                .txtReceiving_Month.Text = Me.dgvForm.Rows(e.RowIndex).Cells(7).Value.ToString.Trim
                .ShowDialog()
            End With
            Me.Populate_Grid()
        End With
    End Sub
End Class