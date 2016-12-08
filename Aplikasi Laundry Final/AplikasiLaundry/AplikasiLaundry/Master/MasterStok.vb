Imports Oracle.DataAccess.Client
Public Class MasterStok


#Region "Prosedur"
    'Sub refreshTabel()
    '    DataGridView1.DataSource = FormLogin.lc.lihatmember().Tables("member")
    '    DataGridView1.Refresh()
    '    With DataGridView1
    '        .Columns(0).HeaderCell.Value = "ID Member"
    '        .Columns(1).HeaderCell.Value = "Nama"
    '        .Columns(2).HeaderCell.Value = "Alamat"
    '        .Columns(3).HeaderCell.Value = "Telepon"
    '        .Columns(4).HeaderCell.Value = "Tgl Lahir"
    '        .Columns(5).HeaderCell.Value = "Jenis Kelamin"
    '    End With
    '    FormLogin.lc.conn.Close()
    'End Sub

    Function textBoxTerisiSemua() As Boolean
        If tb_namastok.Text <> "" And NumericUpDown1.Value <> 0 And cbJenis.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub loadulang()
        tb_idstok.Clear()
        tb_namastok.Clear()
        cbJenis.SelectedIndex = -1
        NumericUpDown1.Value = 0
    End Sub
#End Region
    Private Sub MasterStok_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
    End Sub

    Private Sub MasterStok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FormLogin.lc.loadstok(DataGridView1)
    End Sub


    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click

        If textBoxTerisiSemua() Then
            Try
                Dim iya As Integer = MessageBox.Show("Anda Yakin Insert Stok " & tb_namastok.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
                If iya = DialogResult.Yes Then
                    FormLogin.lc.insstok(tb_idstok.Text, tb_namastok.Text, cbJenis.SelectedItem, NumericUpDown1.Value)
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

        MasterStok_Load(sender, e)
        loadulang()
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        If textBoxTerisiSemua() Then
            Try
                Dim iya As Integer = MessageBox.Show("Anda Yakin Update Stok " & tb_namastok.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
                If iya = DialogResult.Yes Then
                    FormLogin.lc.updstok(tb_idstok.Text, tb_namastok.Text, cbJenis.SelectedItem, NumericUpDown1.Value)
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

        MasterStok_Load(sender, e)
        loadulang()
    End Sub

 
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim barisdgv As Integer = e.RowIndex

        If barisdgv >= 0 Then

            tb_idstok.Text = DataGridView1.Item(0, barisdgv).Value
            tb_namastok.Text = DataGridView1.Item(1, barisdgv).Value
            cbJenis.SelectedItem = DataGridView1.Item(2, barisdgv).Value
            NumericUpDown1.Value = DataGridView1.Item(3, barisdgv).Value
        End If
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        If textBoxTerisiSemua() Then
            Try
                Dim iya As Integer = MessageBox.Show("Anda Yakin Delete Stok " & tb_namastok.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
                If iya = DialogResult.Yes Then
                    FormLogin.lc.delstok(tb_idstok.Text)
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

        MasterStok_Load(sender, e)
        loadulang()
    End Sub
End Class