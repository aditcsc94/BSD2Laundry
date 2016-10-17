Imports Oracle.DataAccess.Client
Public Class Master_Mesin
#Region "modul master member"

    Sub refreshTabel()
        DataGridView1.DataSource = FormLogin.lc.lihatmember().Tables("mesin")
        DataGridView1.Refresh()
        With DataGridView1
            .Columns(0).HeaderCell.Value = "ID Mesin"
            .Columns(1).HeaderCell.Value = "Nama Mesin"
            .Columns(2).HeaderCell.Value = "Jenis"
            .Columns(3).HeaderCell.Value = "Nomer Mesin"
            .Columns(4).HeaderCell.Value = "Catatan"
        End With
        FormLogin.lc.conn.Close()
    End Sub

    Function textBoxTerisiSemua() As Boolean
        If tb_namamesin.Text <> "" And tb_jenis.Text <> "" And tb_catatan.Text <> "" And tb_nomermesin.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Sub loadulang()
        'tb_idmember.Text = FormLogin.lc.autogenidmember
        tb_namamesin.Clear()
        tb_nomermesin.Clear()
        tb_catatan.Clear()
        tb_jenis.Clear()
    End Sub
#End Region
    Private Sub Master_Mesin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        FormUtama.ChildNumber -= 1
    End Sub
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        Dim baris As Integer = e.RowIndex
        If baris >= 0 Then
            tb_idmesin.Text = DataGridView1.Item(0, baris).Value
            tb_namamesin.Text = DataGridView1.Item(1, baris).Value
            tb_jenis.Text = DataGridView1.Item(2, baris).Value
            tb_nomermesin.Text = DataGridView1.Item(3, baris).Value
            'DateTimePicker1.Value = DateTime.ParseExact(DataGridView1.Item(4, baris).Value.ToString(), "dd/MM/yyyy", Globalization.CultureInfo.CurrentCulture, Globalization.DateTimeStyles.None)
            tb_catatan.Text = DataGridView1.Item(4, baris).Value
        End If
    End Sub

    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click
        If textBoxTerisiSemua() Then
            Try
                Dim iya As Integer = MessageBox.Show("Anda Yakin Insert Member " & tb_namamesin.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
                If iya = DialogResult.Yes Then
                    FormLogin.lc.insmesin(tb_idmesin.Text, tb_namamesin.Text, tb_jenis.Text, tb_nomermesin.Text, tb_catatan)
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
        refreshTabel()
        loadulang()
    End Sub
End Class