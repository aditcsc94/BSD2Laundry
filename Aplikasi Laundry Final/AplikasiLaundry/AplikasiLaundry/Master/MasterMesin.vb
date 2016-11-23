Imports Oracle.DataAccess.Client
Public Class MasterMesin
#Region "modul master member"

    Sub refreshTabel()
        DataGridView1.DataSource = FormLogin.lc.lihatmember().Tables("member")
        DataGridView1.Refresh()
        With DataGridView1
            .Columns(0).HeaderCell.Value = "ID Mesin"
            .Columns(1).HeaderCell.Value = "Nama"
            .Columns(2).HeaderCell.Value = "Nomer Mesin"
            .Columns(3).HeaderCell.Value = "Jenis Mesin"
            .Columns(4).HeaderCell.Value = "Catatan"
        End With
        FormLogin.lc.conn.Close()
    End Sub

    Function textBoxTerisiSemua() As Boolean
        If tb_nama.Text <> "" And tb_nomesin.Text <> "" And tb_jenis.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Sub loadulang()
        'tb_idmember.Text = FormLogin.lc.autogenidmember
        tb_nama.Clear()
        tb_nomesin.Clear()
        tb_jenis.Clear()
        tb_catatan.Clear()
    End Sub
#End Region
    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click
        If textBoxTerisiSemua() Then
            Try
                Dim iya As Integer = MessageBox.Show("Anda Yakin Insert Member " & tb_nama.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
                If iya = DialogResult.Yes Then
                    FormLogin.lc.insmesin(tb_idmesin.Text, tb_nama.Text, tb_jenis.Text, tb_nomesin.Text, tb_catatan)
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

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        If textBoxTerisiSemua() Then
            Try
                Dim iya As Integer = MessageBox.Show("Anda Yakin Update Member " & tb_nama.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
                If iya = DialogResult.Yes Then
                    FormLogin.lc.updmesin(tb_idmesin.Text, tb_nama.Text, tb_nomesin.Text, tb_jenis.Text, tb_catatan.Text)

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

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        If tb_idmesin.Text <> "" Then
            Try
                Dim iya As Integer = MessageBox.Show("Anda Yakin Delete Member " & tb_nama.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
                If iya = DialogResult.Yes Then
                    FormLogin.lc.delmesin(tb_idmesin.Text)
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
    Private Sub Master_Mesin_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadulang()
        refreshTabel()
    End Sub
End Class