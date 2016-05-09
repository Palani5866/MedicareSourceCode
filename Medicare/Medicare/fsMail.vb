Public Class fsMail
    Dim Conn As DbConnection = New SqlConnection()
    Dim _objBusi As New Business
    Private Sub fsMail_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        If Conn.State = ConnectionState.Open Then
            Conn.Close()
        End If
    End Sub
    Private Sub fsMail_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Conn.ConnectionString = My.Settings.SQL_Conn
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        End If
        BINDDATA()
    End Sub
    Private Sub BINDDATA()
        Dim dt As New DataTable
        If Me.lblType.Text = "INCOMPLETE" Then
            dt = _objBusi.getMailDetails("SENDMAIL", "", "", "", "", "", "", "", "", "INCOMPLETE", "PROPOSER", Conn)
            Me.gbUW.Visible = True
        Else
            dt = _objBusi.getMailDetails("SENDMAIL", "", "", "", "", "", "", "", "", "", "PROPOSER", Conn)
            Me.gbUW.Visible = False
        End If
        If dt.Rows.Count > 0 Then
            With Me.dgvSendMailDetails
                .DataSource = dt
                .Columns(1).Visible = False
                .Columns(10).Visible = False
            End With
        End If
    End Sub
   
    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try
            Dim dgvRowCount As Integer = 0
            With Me.dgvSendMailDetails
                Do While dgvRowCount < .Rows.Count
                    If .Rows(dgvRowCount).Cells(0).Value = "T" Then
                        If Me.lblType.Text = "INCOMPLETE" Then
                            If vcheck() Then
                                getIncomplete(.Rows(dgvRowCount).Cells(2).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(3).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(4).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(5).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(6).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(7).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(8).Value.ToString.Trim())
                                _objBusi.spUpdate("PROPOSEREMAIL", My.Settings.Username, .Rows(dgvRowCount).Cells(1).Value.ToString.Trim(), "", "", "", "", "", "", "", "", Conn)
                                _objBusi.InsAuditLogs(My.Settings.Username, "Sent email to : " & .Rows(dgvRowCount).Cells(2).Value.ToString.Trim() & "|" & .Rows(dgvRowCount).Cells(3).Value.ToString.Trim() & "|" & .Rows(dgvRowCount).Cells(4).Value.ToString.Trim() & "|" & .Rows(dgvRowCount).Cells(5).Value.ToString.Trim() & "|" & .Rows(dgvRowCount).Cells(6).Value.ToString.Trim() & "|" & .Rows(dgvRowCount).Cells(7).Value.ToString.Trim() & "|" & .Rows(dgvRowCount).Cells(8).Value.ToString.Trim(), Conn)
                            Else
                                MsgBox("Please do select required document!")
                                Exit Sub
                            End If
                        Else
                            getAcknowledgement(.Rows(dgvRowCount).Cells(2).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(3).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(4).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(5).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(6).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(7).Value.ToString.Trim(), .Rows(dgvRowCount).Cells(8).Value.ToString.Trim())
                            _objBusi.spUpdate("PROPOSEREMAIL", My.Settings.Username, .Rows(dgvRowCount).Cells(1).Value.ToString.Trim(), "", "", "", "", "", "", "", "", Conn)
                            _objBusi.InsAuditLogs(My.Settings.Username, "Sent email to : " & .Rows(dgvRowCount).Cells(2).Value.ToString.Trim() & "|" & .Rows(dgvRowCount).Cells(3).Value.ToString.Trim() & "|" & .Rows(dgvRowCount).Cells(4).Value.ToString.Trim() & "|" & .Rows(dgvRowCount).Cells(5).Value.ToString.Trim() & "|" & .Rows(dgvRowCount).Cells(6).Value.ToString.Trim() & "|" & .Rows(dgvRowCount).Cells(7).Value.ToString.Trim() & "|" & .Rows(dgvRowCount).Cells(8).Value.ToString.Trim(), Conn)
                        End If
                    End If
                    dgvRowCount += 1
                Loop
            End With
            MsgBox("Send email successfully")
            BINDDATA()
        Catch ex As Exception
            MsgBox("Error while sending email, Please try again")
        End Try
    End Sub
    Private Function vcheck() As Boolean
        If Me.cbBorangAngkasaBPA179TCMT.Checked Then
            Return True
        ElseIf Me.cbBorangAngkasaBPA179TD.Checked Then
            Return True
        ElseIf Me.cbBorangPermohonanTL.Checked Then
            Return True
        ElseIf Me.cbMaklumatAhliKTL.Checked Then
            Return True
        ElseIf Me.cbSalinanKPTD.Checked Then
            Return True
        ElseIf Me.cbSalinanSlipGTJTD.Checked Then
            Return True
        End If
        Return False
    End Function

    Private Sub getAcknowledgement(ByVal title As String, ByVal IC As String, ByVal full_name As String, ByVal plancode As String, ByVal plantype As String, ByVal proposalreceiveddate As String, ByVal email As String)
        Dim sTo, sCC, DisplayName As String
        Dim sMsg, sSub, sHeader, sFooter As String
        sSub = "Pengesahan Penerimaan"
        sFooter = "Yang Benar," & vbCrLf
        sFooter = sFooter & " Pegawai Tadbir, " & vbCrLf
        sFooter = sFooter & " Medicare Assistance Sdn Bhd (492830-K), " & vbCrLf
        sFooter = sFooter & " B-5-3A, Pusat Perdagangan Intania " & vbCrLf
        sFooter = sFooter & " Jalan Intan, Persiaran Raja Muda Musa " & vbCrLf
        sFooter = sFooter & " 41200 Klang, Selangor Darul Ehsan " & vbCrLf
        sFooter = sFooter & " Tel: 0333714248  Fax: 0333714258 " & vbCrLf
        sFooter = sFooter & " www.cuepacscare.my " & vbCrLf
        sMsg = sMsg & title & " " & full_name & ", No. K/P      : " & IC & vbCrLf & vbCrLf
        sMsg = sMsg & " Salam hormat kepada anda." & vbCrLf & vbCrLf
        sMsg = sMsg & " Kami mengucapkan terima kasih diatas permohonan Skim Takaful Kelompok " & plancode & "." & vbCrLf & vbCrLf
        sMsg = sMsg & " Kami mengesahkan penerimaan dokumen-dokumen permohonan anda yang lengkap pada : " & proposalreceiveddate & "." & vbCrLf & vbCrLf
        sMsg = sMsg & " Harap maklum bahawa, selepas sumbangan pertama (potongan gaji) diterima daripada ANGKASA, perlindungan akan berkuatkuasa pada hari ke-15 bulan berikutnya dan BUKAN dari tarikh potongan gaji. " & vbCrLf & vbCrLf
        sMsg = sMsg & " Untuk sebarang pertanyaan, sila emel atau hubungi Pegawai Khidmat Pelanggan kami di talian 03 3371 4248. " & vbCrLf & vbCrLf
        sMsg = sMsg & " Terimakasih diatas sokongan anda. " & vbCrLf
        sMsg = sMsg & vbCrLf
        Dim sRes As String
        sRes = sMsg
        sTo = email
        DisplayName = "Medicare (Cuepacs Care/Cuepacs PA)"
        _objBusi.SendEmail(sSub, sHeader, sMsg, sFooter, sTo, sCC, DisplayName)
    End Sub
    Private Sub getIncomplete(ByVal title As String, ByVal IC As String, ByVal fullname As String, ByVal plancode As String, ByVal plantype As String, ByVal proposalreceiveddate As String, ByVal email As String)
        Dim sTo, sCC, DisplayName As String
        Dim sMsg, sSub, sHeader, sFooter As String
        Dim i As Integer = 1
        sSub = " Dokumen Permohonan Tidak Lengkap"
        sFooter = "Yang Benar," & vbCrLf
        sFooter = sFooter & " Pegawai Tadbir, " & vbCrLf
        sFooter = sFooter & " Medicare Assistance Sdn Bhd (492830-K), " & vbCrLf
        sFooter = sFooter & " B-5-3A, Pusat Perdagangan Intania " & vbCrLf
        sFooter = sFooter & " Jalan Intan, Persiaran Raja Muda Musa " & vbCrLf
        sFooter = sFooter & " 41200 Klang, Selangor Darul Ehsan " & vbCrLf
        sFooter = sFooter & " Tel: 0333714248  Fax: 0333714258 " & vbCrLf
        sFooter = sFooter & " www.cuepacscare.my " & vbCrLf


        sMsg = sMsg & title & " " & fullname & ", No. K/P  : " & IC & vbCrLf & vbCrLf
        
        sMsg = sMsg & " Salam hormat kepada anda." & vbCrLf & vbCrLf
        sMsg = sMsg & " Kami mengucapkan terima kasih diatas permohonan Skim Takaful Kelompok " & plancode & "." & vbCrLf
        sMsg = sMsg & " Walaubagaimanapun, kami tidak dapat memproses permohonan anda kerana maklumat berikut tidak disertakan / tidak lengkap. " & vbCrLf & vbCrLf

        If Me.cbSalinanKPTD.Checked Then
            sMsg = sMsg & " * Salinan K/P Tidak Disertakan" & vbCrLf
        End If
        If Me.cbSalinanSlipGTJTD.Checked Then
            sMsg = sMsg & " * Salinan Slip Gaji Terkini & Jelas Tidak Disertakan " & vbCrLf
        End If
        If Me.cbBorangPermohonanTL.Checked Then
            sMsg = sMsg & " * Borang Permohonan Tidak Lengkap " & vbCrLf
        End If
        If Me.cbBorangAngkasaBPA179TD.Checked Then
            sMsg = sMsg & " * Borang Angkasa BPA 1/79 Tidak Disertakan (Borang akan diposkan untuk dilengkapkan)" & vbCrLf
        End If
        If Me.cbBorangAngkasaBPA179TCMT.Checked Then
            sMsg = sMsg & " * Borang Angkasa BPA 1/79 Tiada Cop Majikan/Tandatangan (Borang akan diposkan untuk dilengkapkan) " & vbCrLf
        End If
        If Me.cbMaklumatAhliKTL.Checked Then
            sMsg = sMsg & " * Maklumat Ahli Keluarga Tidak Lengkap " & vbCrLf
        End If
        sMsg = sMsg & vbCrLf & vbCrLf
        sMsg = sMsg & " Sila emelkan/poskan dokumen / maklumat yang diperlukan dengan segera kepada kami. " & vbCrLf & vbCrLf
        sMsg = sMsg & " Terimakasih diatas sokongan anda. " & vbCrLf & vbCrLf
        sMsg = sMsg & vbCrLf
        Dim sRes As String
        sRes = sMsg
        sTo = email
        DisplayName = "Medicare (Cuepacs Care/Cuepacs PA)"
        _objBusi.SendEmail(sSub, sHeader, sMsg, sFooter, sTo, sCC, DisplayName)
    End Sub
    Private Sub btnDiscard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiscard.Click
        Me.Close()
    End Sub
    Private Sub tsb_Filter_Go_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsb_Filter_Go.Click
        If Me.tsb_Filter.SelectedIndex = 1 Then
            If Me.tsb_Filter_Param.Text = "" Then
                MsgBox("Please do key in Proposer IC")
                Me.tsb_Filter_Param.Focus()
                Exit Sub
            End If
            sBINDDATA()
        ElseIf Me.tsb_Filter.SelectedIndex = 2 Then
            If Me.tsb_Filter_Param.Text = "" Then
                MsgBox("Please do key in Proposer Name")
                Me.tsb_Filter_Param.Focus()
                Exit Sub
            End If
            sBINDDATA()
        Else

            BINDDATA()
        End If
    End Sub
    Private Sub dgvSendMailDetails_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles dgvSendMailDetails.DataBindingComplete
        For i As Integer = 0 To dgvSendMailDetails.Rows.Count - 1
            If Not IsDBNull(dgvSendMailDetails.Rows(i).Cells(10).Value) Then
                If Not IsNothing(dgvSendMailDetails.Rows(i).Cells(10).Value) Then
                    If dgvSendMailDetails.Rows(i).Cells(10).Value Then
                        dgvSendMailDetails.Rows(i).DefaultCellStyle.BackColor = Color.FromArgb(240, 128, 128)
                    End If
                End If
            End If
        Next
    End Sub
    Private Sub sBINDDATA()
        Dim dt As New DataTable
        If Me.lblType.Text = "INCOMPLETE" Then
            If Me.tsb_Filter.SelectedIndex = 1 Then
                dt = _objBusi.getMailDetails("SENDMAIL", "IC", Me.tsb_Filter_Param.Text.ToString.Trim(), "", "", "", "", "", "", "INCOMPLETE", "PROPOSER", Conn)
            Else
                dt = _objBusi.getMailDetails("SENDMAIL", "FULLNAME", Me.tsb_Filter_Param.Text.ToString.Trim(), "", "", "", "", "", "", "INCOMPLETE", "PROPOSER", Conn)
            End If
            Me.gbUW.Visible = True
        Else
            If Me.tsb_Filter.SelectedIndex = 1 Then
                dt = _objBusi.getMailDetails("SENDMAIL", "IC", Me.tsb_Filter_Param.Text.ToString.Trim(), "", "", "", "", "", "", "", "PROPOSER", Conn)
            Else
                dt = _objBusi.getMailDetails("SENDMAIL", "FULLNAME", Me.tsb_Filter_Param.Text.ToString.Trim(), "", "", "", "", "", "", "", "PROPOSER", Conn)
            End If
            Me.gbUW.Visible = False
        End If
        If dt.Rows.Count > 0 Then
            With Me.dgvSendMailDetails
                .DataSource = dt
                .Columns(1).Visible = False
            End With
        Else
            MsgBox("No record found / no email address, Please check with admin!")
            Me.dgvSendMailDetails.DataSource = dt
        End If
    End Sub
End Class