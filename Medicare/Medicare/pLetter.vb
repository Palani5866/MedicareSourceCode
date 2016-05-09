Public Class pLetter
    Dim Conn As DbConnection = New SqlConnection
    Dim _objBusi As New Business
    Dim sType As String
    Private Sub pLetter_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub pLetter_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        If sType = "SEARCH" Then
            dt = _objBusi.getDetails("PLETTERS", Me.lblType.Text.Trim(), Me.tsLetter_cbLetterType.Text.Trim(), Me.tstbSearch.Text.Trim(), "", "SEARCH", Conn)
        Else
            dt = _objBusi.getDetails("PLETTERS", Me.lblType.Text.Trim(), "", "", "", "", Conn)
        End If
        If dt.Rows.Count > 0 Then
            With Me.dgvLetters
                .DataSource = dt
                .Columns(1).Visible = False 'ID
                .Columns(2).HeaderText = "IC #"
                .Columns(3).HeaderText = "FULL NAME"
                .Columns(4).HeaderText = "PLAN CODE"
                .Columns(5).HeaderText = "PLAN TYPE"
                .Columns(6).HeaderText = "PROPOSAL RECEIVED DATE"
                .Columns(7).HeaderText = "ANGKASA FILE #"
                .Columns(8).HeaderText = "STATUS"
                .Columns(0).DisplayIndex = 8
                .Columns(0).HeaderText = "Print"
                Me.lblRecordCount.Text = "Record #: " & Me.dgvLetters.RowCount - 1
            End With
        Else
            MsgBox("No Record found...")
        End If
    End Sub
    Private Sub tsLetter_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsLetter_Go.Click
        sType = "SEARCH"
        If Len(Me.tstbSearch.Text.Trim()) = 0 Then
            MsgBox("Please do key in IC/full name")
            Me.tstbSearch.Focus()
            Exit Sub
        End If
        If Len(Me.tsLetter_cbLetterType.Text.Trim()) = 0 Then
            MsgBox("Please do select search type")
            Me.tsLetter_cbLetterType.Focus()
            Exit Sub
        End If
        BINDDATA()
    End Sub
    Private Sub dgvLetters_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLetters.CellContentClick
        Dim type As String
        type = Me.lblType.Text.Trim()
        Select Case type
            Case "1A"
                With Me.dgvLetters
                    If e.ColumnIndex = 0 Then
                        If .Rows.Count = 0 Then
                            Exit Sub
                        End If
                        Dim p As String
                        Dim aP As String()
                        p = .Rows(e.RowIndex).Cells(4).Value.ToString().Trim()
                        aP = p.Split("-")
                        If aP(1).Substring(0, 1) = "Y" Then
                            Print1AAY(.Rows(e.RowIndex).Cells(1).Value.ToString().Trim())
                        Else
                           Print1AA(.Rows(e.RowIndex).Cells(1).Value.ToString().Trim())
                        End If

                    End If
                End With
            Case "1D"
                With Me.dgvLetters
                    If e.ColumnIndex = 0 Then
                        If .Rows.Count = 0 Then
                            Exit Sub
                        End If
                        Print1D(.Rows(e.RowIndex).Cells(1).Value.ToString().Trim())
                    End If
                End With
            Case "1R"
                With Me.dgvLetters
                    If e.ColumnIndex = 0 Then
                        If .Rows.Count = 0 Then
                            Exit Sub
                        End If
                        Print1R(.Rows(e.RowIndex).Cells(1).Value.ToString().Trim())
                    End If
                End With
            Case "1U"
                With Me.dgvLetters
                    If e.ColumnIndex = 0 Then
                        If .Rows.Count = 0 Then
                            Exit Sub
                        End If

                        PrintLetters.PrintProposer("UW.rpt", .Rows(e.RowIndex).Cells(1).Value.ToString().Trim(), "UW")
                    End If
                End With
        End Select
    End Sub
    Private Sub Print1AA(ByVal pID As String)
        Dim dt As New DataTable
        dt = _objBusi.getDetails("PLPRINT", pID, "", "", "", "MA", Conn)

        Dim rpt_acknowledgement As New Acknowledgement
        rpt_acknowledgement.lblProposer_ID.Text = pID.Trim()
        rpt_acknowledgement.lblPlancode.Text = dt.Rows(0)("PLAN_CODE").ToString().Trim()

        Dim rpt_address As New DataTable
        rpt_address.Columns.Add("Col 1")

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTAL_ADDRESS_L1").ToString().Trim()

        If Len(dt.Rows(0)("POSTAL_ADDRESS_L2").ToString().Trim()) > 0 Then
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTAL_ADDRESS_L2").ToString().Trim()
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTCODE").ToString().Trim() & " " & dt.Rows(0)("TOWN").ToString().Trim()

        Else
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTCODE").ToString().Trim() & " " & dt.Rows(0)("TOWN").ToString().Trim()
        End If

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("STATE").ToString().Trim()

        Select Case rpt_address.Rows.Count
            Case 3
                rpt_acknowledgement.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL4.Text = " "
            Case 4
                rpt_acknowledgement.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_acknowledgement.LabelL4.Text = rpt_address.Rows(3).Item(0).ToString.Trim
        End Select
        rpt_acknowledgement.Show()
    End Sub
    Private Sub Print1AAY(ByVal pID As String)
        Dim dt As New DataTable
        dt = _objBusi.getDetails("PLPRINT", pID, "", "", "", "MA", Conn)

        Dim rpt_YearlyLetter As New Yearly_PlanLetter_Proposer
        rpt_YearlyLetter.lblProposer_ID.Text = pID.Trim()
        rpt_YearlyLetter.lblPlancode.Text = dt.Rows(0)("PLAN_CODE").ToString().Trim()


        Dim rpt_address As New DataTable
        rpt_address.Columns.Add("Col 1")

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTAL_ADDRESS_L1").ToString().Trim()

        If Len(dt.Rows(0)("POSTAL_ADDRESS_L2").ToString().Trim()) > 0 Then
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTAL_ADDRESS_L2").ToString().Trim()
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTCODE").ToString().Trim() & " " & dt.Rows(0)("TOWN").ToString().Trim()

        Else
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTCODE").ToString().Trim() & " " & dt.Rows(0)("TOWN").ToString().Trim()
        End If

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("STATE").ToString().Trim()

        Select Case rpt_address.Rows.Count
            Case 3
                rpt_YearlyLetter.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_YearlyLetter.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_YearlyLetter.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_YearlyLetter.LabelL4.Text = " "
            Case 4
                rpt_YearlyLetter.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_YearlyLetter.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_YearlyLetter.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_YearlyLetter.LabelL4.Text = rpt_address.Rows(3).Item(0).ToString.Trim
        End Select

        rpt_YearlyLetter.Show()
    End Sub
    Private Sub Print1D(ByVal pID As String)
        Dim dt As New DataTable
        dt = _objBusi.getDetails("PLPRINT", pID, "", "", "", "MA", Conn)
        Dim rpt_deferment As New Deferment
        rpt_deferment.lblProposer_ID.Text = pID.Trim()
        rpt_deferment.lblPlanCode.Text = dt.Rows(0)("PLAN_CODE").ToString().Trim()

        Dim rpt_address As New DataTable
        rpt_address.Columns.Add("Col 1")

        Dim rpt_deferments As New Deferment
        rpt_deferments.lblProposer_ID.Text = pID.Trim()

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTAL_ADDRESS_L1").ToString().Trim()

        If Len(dt.Rows(0)("POSTAL_ADDRESS_L2").ToString().Trim()) > 0 Then
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTAL_ADDRESS_L2").ToString().Trim()
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTCODE").ToString().Trim() & " " & dt.Rows(0)("TOWN").ToString().Trim()

        Else
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTCODE").ToString().Trim() & " " & dt.Rows(0)("TOWN").ToString().Trim()
        End If

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("STATE").ToString().Trim()


        Select Case rpt_address.Rows.Count
            Case 3
                rpt_deferment.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_deferment.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_deferment.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_deferments.LabelL4.Text = " "
            Case 4
                rpt_deferment.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_deferment.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_deferment.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_deferment.LabelL4.Text = rpt_address.Rows(3).Item(0).ToString.Trim

        End Select


        Dim rpt_errorfields As New DataTable
        rpt_errorfields.Columns.Add("Col 1")

        If dt.Rows(0)("Document_Checklist_Application_Form") = False Then
            rpt_errorfields.Rows.Add()
            rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Borang Permohonan Tidak Disertakan"
        Else
            Select Case dt.Rows(0)("Document_Checklist_Application_Form_Status")
                Case "Lengkap"

                Case "Tidak Lengkap"
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Borang Permohonan Tidak Lengkap "
                    If Not IsDBNull(dt.Rows(0)("DCAF_Status")) Then
                        Dim s1 As String
                        s1 = dt.Rows(0)("DCAF_Status")
                        Dim sMsg() As String
                        sMsg = s1.Split("!")
                        For Each str As String In sMsg
                            Select Case str.Trim()
                                Case "-Bahagian A (Tarikh Lahir)"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian A (Tarikh Lahir)"
                                Case "-Bahagian A (No Telefon)"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian A (No Telefon)"
                                Case "-Bahagian B (No Kad Pengenalan Pasangan)"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian B (No Kad Pengenalan Pasangan)"
                                Case "-Bahagian B (No Sijil Kelahiran / No Kad Pengenalan Anak)"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian B (No Sijil Kelahiran / No Kad Pengenalan Anak)"
                                Case "-Bahagian B (Surat Pengambilan Anak Angkat)"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian B (Surat Pengambilan Anak Angkat)"
                                Case "-Bahagian B (Sertakan Sijil Kelahiran Anak)"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian B (Sertakan Sijil Kelahiran Anak)"
                                Case "-Bahagian B (Pasangan / Anak Melebihi had Kelayakan Umur)"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian B (Pasangan / Anak Melebihi had Kelayakan Umur)"
                                Case "-Bahagian C (Soal Selidik)"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian C (Soal Selidik)"
                                Case "-Bahagian D & E (Tandatangan Pemohon)"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian D & E (Tandatangan Pemohon)"
                                Case "-Jenis Pilihan Pelan"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Jenis Pilihan Pelan"
                                Case "-Bahagian Penamaan"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian Penamaan"
                                Case "-Bahagian Pengisytiharan (Tandatangan Pemohon)"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Bahagian Pengisytiharan (Tandatangan Pemohon)"
                                Case "-Seksyen D (Tandatangan Saksi)"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Seksyen D (Tandatangan Saksi)"
                                Case "-Seksyen D (Tandatangan Pemilik)"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Seksyen D (Tandatangan Pemilik)"
                            End Select
                        Next
                    End If
                Case "Borang Lama"
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Borang Permohonan Borang Lama"
            End Select
        End If

        If dt.Rows(0)("Document_Checklist_IC") = False Then
            rpt_errorfields.Rows.Add()
            rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Salinan Kad Pengenalan / Tidak Disertakan"
        End If

        If dt.Rows(0)("Document_Checklist_Penyata") = True Then
            If Not IsDBNull(dt.Rows(0)("Document_Checklist_Penyata_STATUS")) Then
                If dt.Rows(0)("Document_Checklist_Penyata_STATUS") = "Tidak Jelas" Then
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Salinan Slip > 6 Bulan / Tidak Jelas"
                    
                Else
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Salinan Slip Gaji Terbaru"
                End If
                
            End If
        Else
            rpt_errorfields.Rows.Add()
            rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Salinan Slip Gaji Terbaru"
        End If
        If dt.Rows(0)("Document_Checklist_Payslip") = True Then
            Select Case dt.Rows(0)("Document_Checklist_Payslip_Status")
                
                Case "Tidak Jelas"
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Salinan Slip Gaji Terkini / Tidak Jelas"
            End Select
        Else
            rpt_errorfields.Rows.Add()
            rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Salinan Slip Gaji Tidak Disertakan"
        End If


        If dt.Rows(0)("Document_Checklist_Borang1_79") = True Then
            Select Case dt.Rows(0)("Document_Checklist_Borang1_79_Status")
                Case "Lengkap dengan Maklumat Majikan dan Cop Majikan"
                    
                Case "Terdapat kesilapan mengisi Borang 1/79"
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Terdapat Kesilapan Mengisi Borang 1/79"
                Case "Penggunaan 'liquid paper' pada Borang 1/79"
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Penggunaan 'liquid paper' pada borang 1/79"
                Case "Muat Turun Borang 1/79"
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Muat Turun Borang 1/79"
                Case "Tidak Lengkap"
                    rpt_errorfields.Rows.Add()
                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Borang 1/79(Angkasa) Tidak Lengkap"
                    If Not IsDBNull(dt.Rows(0)("DCB179_Status")) Then
                        Dim s1 As String
                        s1 = dt.Rows(0)("DCB179_Status")
                        Dim sMsg1() As String
                        sMsg1 = s1.Split("!")
                        For Each str1 As String In sMsg1
                            Select Case str1.Trim()
                                Case "Tandatangan Pemohon"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Tandatangan Pemohon"
                                Case "Cop Majikan"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Cop Majikan"
                                Case "Tandatangan Majikan"
                                    rpt_errorfields.Rows.Add()
                                    rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "-Tandatangan Majikan"
                            End Select
                        Next
                    End If
            End Select
        Else
            rpt_errorfields.Rows.Add()
            rpt_errorfields.Rows(rpt_errorfields.Rows.Count - 1).Item(0) = "* Borang 1/79 Tidak Disertakan"
        End If
        Dim s As String
        s = rpt_errorfields.Rows.Count
        Select Case rpt_errorfields.Rows.Count
            Case 1
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = ""
                rpt_deferment.Label3.Text = ""
                rpt_deferment.Label4.Text = ""
                rpt_deferment.Label5.Text = ""
                rpt_deferment.Label6.Text = ""
                rpt_deferment.Label7.Text = ""
                rpt_deferment.Label8.Text = ""
                rpt_deferment.Label9.Text = ""
            Case 2
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = ""
                rpt_deferment.Label4.Text = ""
                rpt_deferment.Label5.Text = ""
                rpt_deferment.Label6.Text = ""
                rpt_deferment.Label7.Text = ""
                rpt_deferment.Label8.Text = ""
                rpt_deferment.Label9.Text = ""
            Case 3
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = rpt_errorfields.Rows(2).Item(0).ToString.Trim
                rpt_deferment.Label4.Text = ""
                rpt_deferment.Label5.Text = ""
                rpt_deferment.Label6.Text = ""
                rpt_deferment.Label7.Text = ""
                rpt_deferment.Label8.Text = ""
                rpt_deferment.Label9.Text = ""
            Case 4
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = rpt_errorfields.Rows(2).Item(0).ToString.Trim
                rpt_deferment.Label4.Text = rpt_errorfields.Rows(3).Item(0).ToString.Trim
                rpt_deferment.Label5.Text = ""
                rpt_deferment.Label6.Text = ""
                rpt_deferment.Label7.Text = ""
                rpt_deferment.Label8.Text = ""
                rpt_deferment.Label9.Text = ""
            Case 5
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = rpt_errorfields.Rows(2).Item(0).ToString.Trim
                rpt_deferment.Label4.Text = rpt_errorfields.Rows(3).Item(0).ToString.Trim
                rpt_deferment.Label5.Text = rpt_errorfields.Rows(4).Item(0).ToString.Trim
                rpt_deferment.Label6.Text = ""
                rpt_deferment.Label7.Text = ""
                rpt_deferment.Label8.Text = ""
                rpt_deferment.Label9.Text = ""
            Case 6
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = rpt_errorfields.Rows(2).Item(0).ToString.Trim
                rpt_deferment.Label4.Text = rpt_errorfields.Rows(3).Item(0).ToString.Trim
                rpt_deferment.Label5.Text = rpt_errorfields.Rows(4).Item(0).ToString.Trim
                rpt_deferment.Label6.Text = rpt_errorfields.Rows(5).Item(0).ToString.Trim
                rpt_deferment.Label7.Text = ""
                rpt_deferment.Label8.Text = ""
                rpt_deferment.Label9.Text = ""
            Case 7
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = rpt_errorfields.Rows(2).Item(0).ToString.Trim
                rpt_deferment.Label4.Text = rpt_errorfields.Rows(3).Item(0).ToString.Trim
                rpt_deferment.Label5.Text = rpt_errorfields.Rows(4).Item(0).ToString.Trim
                rpt_deferment.Label6.Text = rpt_errorfields.Rows(5).Item(0).ToString.Trim
                rpt_deferment.Label7.Text = rpt_errorfields.Rows(6).Item(0).ToString.Trim
                rpt_deferment.Label8.Text = ""
                rpt_deferment.Label9.Text = ""
            Case 8
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = rpt_errorfields.Rows(2).Item(0).ToString.Trim
                rpt_deferment.Label4.Text = rpt_errorfields.Rows(3).Item(0).ToString.Trim
                rpt_deferment.Label5.Text = rpt_errorfields.Rows(4).Item(0).ToString.Trim
                rpt_deferment.Label6.Text = rpt_errorfields.Rows(5).Item(0).ToString.Trim
                rpt_deferment.Label7.Text = rpt_errorfields.Rows(6).Item(0).ToString.Trim
                rpt_deferment.Label8.Text = rpt_errorfields.Rows(7).Item(0).ToString.Trim
                rpt_deferment.Label9.Text = ""
            Case 9
                rpt_deferment.Label1.Text = rpt_errorfields.Rows(0).Item(0).ToString.Trim
                rpt_deferment.Label2.Text = rpt_errorfields.Rows(1).Item(0).ToString.Trim
                rpt_deferment.Label3.Text = rpt_errorfields.Rows(2).Item(0).ToString.Trim
                rpt_deferment.Label4.Text = rpt_errorfields.Rows(3).Item(0).ToString.Trim
                rpt_deferment.Label5.Text = rpt_errorfields.Rows(4).Item(0).ToString.Trim
                rpt_deferment.Label6.Text = rpt_errorfields.Rows(5).Item(0).ToString.Trim
                rpt_deferment.Label7.Text = rpt_errorfields.Rows(6).Item(0).ToString.Trim
                rpt_deferment.Label8.Text = rpt_errorfields.Rows(7).Item(0).ToString.Trim
                rpt_deferment.Label9.Text = rpt_errorfields.Rows(8).Item(0).ToString.Trim
        End Select

        rpt_deferment.Show()
    End Sub
    Private Sub Print1R(ByVal pID As String)
        Dim dt As New DataTable
        dt = _objBusi.getDetails("PLPRINT", pID, "", "", "", "MA", Conn)

        Dim rpt_reject As New Rejection
        rpt_reject.lblProposer_ID.Text = pID.Trim()
        rpt_reject.lblReject_Reason.Text = dt.Rows(0)("Decline_Reason").ToString().Trim()
        rpt_reject.lblPlanCode.Text = dt.Rows(0)("PLAN_CODE").ToString().Trim()

        Dim rpt_address As New DataTable
        rpt_address.Columns.Add("Col 1")
        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTAL_ADDRESS_L1").ToString().Trim()

        If Len(dt.Rows(0)("POSTAL_ADDRESS_L2").ToString().Trim()) > 0 Then
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTAL_ADDRESS_L2").ToString().Trim()
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTCODE").ToString().Trim() & " " & dt.Rows(0)("TOWN").ToString().Trim()

        Else
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTCODE").ToString().Trim() & " " & dt.Rows(0)("TOWN").ToString().Trim()
        End If

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("STATE").ToString().Trim()

        Select Case rpt_address.Rows.Count
            Case 3
                rpt_reject.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_reject.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_reject.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_reject.LabelL4.Text = " "
            Case 4
                rpt_reject.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_reject.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_reject.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_reject.LabelL4.Text = rpt_address.Rows(3).Item(0).ToString.Trim
        End Select
        rpt_reject.Show()
    End Sub
    Private Sub Print1U(ByVal pID As String)
        Dim dt As New DataTable
        dt = _objBusi.getDetails("PLPRINT", pID, "", "", "", "MA", Conn)
        
        Dim rpt_underwriting_P1 As New Underwriting
        rpt_underwriting_P1.lblProposer_ID.Text = pID.Trim()
        rpt_underwriting_P1.lblUnderWriting_ID.Text = "P1"


        Dim rpt_address As New DataTable
        rpt_address.Columns.Add("Col 1")
        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTAL_ADDRESS_L1").ToString().Trim()

        If Len(dt.Rows(0)("POSTAL_ADDRESS_L2").ToString().Trim()) > 0 Then
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTAL_ADDRESS_L2").ToString().Trim()
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTCODE").ToString().Trim() & " " & dt.Rows(0)("TOWN").ToString().Trim()

        Else
            rpt_address.Rows.Add()
            rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("POSTCODE").ToString().Trim() & " " & dt.Rows(0)("TOWN").ToString().Trim()
        End If

        rpt_address.Rows.Add()
        rpt_address.Rows(rpt_address.Rows.Count - 1).Item(0) = dt.Rows(0)("STATE").ToString().Trim()

        Select Case rpt_address.Rows.Count
            Case 3
                rpt_underwriting_P1.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_underwriting_P1.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_underwriting_P1.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_underwriting_P1.LabelL4.Text = " "

            Case 4
                rpt_underwriting_P1.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_underwriting_P1.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_underwriting_P1.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_underwriting_P1.LabelL4.Text = rpt_address.Rows(3).Item(0).ToString.Trim

        End Select

        rpt_underwriting_P1.ShowDialog()



        Dim rpt_underwriting_P2 As New Underwriting
        rpt_underwriting_P2.lblProposer_ID.Text = pID.Trim()
        rpt_underwriting_P2.lblUnderWriting_ID.Text = "P2"
        Select Case rpt_address.Rows.Count
            Case 3
                rpt_underwriting_P2.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_underwriting_P2.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_underwriting_P2.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_underwriting_P2.LabelL4.Text = " "
            Case 4
                rpt_underwriting_P2.LabelL1.Text = rpt_address.Rows(0).Item(0).ToString.Trim
                rpt_underwriting_P2.LabelL2.Text = rpt_address.Rows(1).Item(0).ToString.Trim
                rpt_underwriting_P2.LabelL3.Text = rpt_address.Rows(2).Item(0).ToString.Trim
                rpt_underwriting_P2.LabelL4.Text = rpt_address.Rows(3).Item(0).ToString.Trim

        End Select

        rpt_underwriting_P2.ShowDialog()
    End Sub
End Class