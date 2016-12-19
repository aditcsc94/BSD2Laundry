Imports Oracle.DataAccess.Client
Public Class History_mesin
    Dim namamsn As String
    Dim nomermesin As String
    Public idperbaikan As String
#Region "history mesin"
    Function textBoxTerisiSemua() As Boolean
        If tb_nama.Text <> "" And tb_nomesin.Text <> "" And tb_perbaikan.Text <> "" And tb_biaya.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Sub loadulang()
        tb_idmesin.Clear()
        tb_nama.Clear()
        tb_nomesin.Clear()
        tb_perbaikan.Clear()
        tb_masalah.Clear()
        tb_biaya.Clear()
    End Sub

    'Sub querymesin()
    '    Try
    '        If FormLogin.lc.conn.State = ConnectionState.Closed Then
    '            FormLogin.lc.conn.Open()
    '        End If
    '        Dim cmd As New OracleCommand("SELECT idmesin, nama, nomermesin  FROM mesin where  idmesin='" + cmbidmesin.SelectedValue + "'", FormLogin.lc.conn)
    '        Dim rd As OracleDataReader = cmd.ExecuteReader()
    '        While rd.Read

    '            namamsn = rd("nama")
    '            nomermesin = rd("nomermesin")
    '        End While

    '    Catch ex As Exception

    '        MsgBox(ex.Message)

    '    End Try


    'End Sub
#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormLogin.lc.loadhistory(DataGridView1)
        loadulang()
        'Panel1.Hide()
        'Panel2.Hide()
        idperbaikan = FormLogin.lc.autogenidperbaikan()


        'FormLogin.lc.loadidmesin(cmbidmesin)

    End Sub

    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click
        Dim tanggal As String
        Dim status As String = "Di Perbaiki"
        tanggal = DateTimePicker1.Value.ToString("dd-mm-yyyy")
        If textBoxTerisiSemua() Then
            Try
                Dim iya As Integer = MessageBox.Show("Anda Yakin Insert Perbaikan Mesin " & tb_nama.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
                If iya = DialogResult.Yes Then
                    FormLogin.lc.inshistorymesin(idperbaikan, CStr(tb_idmesin.Text), tb_masalah.Text, tanggal, tb_perbaikan.Text, CInt(tb_biaya.Text), tb_lokasi.Text, status)
                End If
            Catch ex As OracleException
                If ex.Number = 947 Then
                    MsgBox("Data Yang Dimasukkan Terlalu Panjang")
                Else
                    MsgBox(ex.Message)
                End If
            End Try

        Else

        End If


        loadulang()
        Form1_Load(sender, e)

        'refreshTabel()
    End Sub

    Private Sub History_mesin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Dim tanggal As String
        Dim status As String = "Di Pebaiki"
        tanggal = DateTimePicker1.Value.ToString("dd-mm-yyyy")
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        Dim status As String = "Di Hapus"
        If tb_idmesin.Text <> "" Then
            Try
                Dim iya As Integer = MessageBox.Show("Anda Yakin Delete Data Mesin " & tb_nama.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
                If iya = DialogResult.Yes Then
                    FormLogin.lc.delhistorymesin(tb_perbaikan.Text, status)
                End If
            Catch ex As OracleException
                If ex.Number = 1 Then
                    MsgBox("Data Yang Anda Masukkan Sudah Ada")
                ElseIf ex.Number = 947 Then
                    MsgBox("Data Yang Dimasukkan Terlalu Panjang")
                Else
                    MsgBox(ex.Message)
                End If
            End Try
            FormLogin.lc.conn.Close()
        Else
            MsgBox("Harap Isi Data Yang Kosong")
        End If
        FormLogin.lc.loadmesin(DataGridView1)
        loadulang()
    End Sub
End Class