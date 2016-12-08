﻿Imports Oracle.DataAccess.Client
Public Class History_mesin
#Region "history mesin"
    Sub refreshTabel()
        DataGridView1.DataSource = FormLogin.lc.lihatmesin().Tables("mesin")
        DataGridView1.Refresh()
        With DataGridView1
            .Columns(0).HeaderCell.Value = "ID History"
            .Columns(1).HeaderCell.Value = "ID Mesin"
            .Columns(2).HeaderCell.Value = "Status"
            .Columns(3).HeaderCell.Value = "Tanggal Keluar"
            .Columns(4).HeaderCell.Value = "Tanggal Masuk"
            .Columns(5).HeaderCell.Value = "Biaya"
        End With
        FormLogin.lc.conn.Close()
    End Sub
    Function textBoxTerisiSemua() As Boolean
        If tb_idmesin.Text <> "" And tb_nama.Text <> "" And tb_nomesin.Text <> "" And tb_perbaikan.Text <> "" And tb_biaya.Text <> "" Then
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
#End Region
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        refreshTabel()
        loadulang()
        If RadioButton1.Checked = True Then
            Panel1.Visible = True
            Panel2.Visible = False
        Else
            Panel1.Visible = False
            Panel2.Visible = True
        End If
    End Sub

    Private Sub btn_insert_Click(sender As Object, e As EventArgs) Handles btn_insert.Click
        Dim tanggal As String
        Dim status As String
        tanggal = DateTimePicker1.Value.ToString("dd-mm-yyyy")
        If textBoxTerisiSemua() Then
            If RadioButton1.Checked Then
                status = "Di Perbaiki"
                Try
                    Dim iya As Integer = MessageBox.Show("Anda Yakin Insert History Mesin " & tb_nama.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
                    If iya = DialogResult.Yes Then
                        FormLogin.lc.inshistorymesin(tb_idmesin.Text, tb_idmesin.Text, tanggal, tb_masalah.Text, status)
                    End If
                Catch ex As OracleException
                    If ex.Number = 947 Then
                        MsgBox("Data Yang Dimasukkan Terlalu Panjang")
                    Else
                        MsgBox(ex.Message)
                    End If
                End Try
            Else
                status = "Sudah Kembali"
                Try
                    Dim iya As Integer = MessageBox.Show("Anda Yakin Update Data History Mesin " & tb_nama.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
                    If iya = DialogResult.Yes Then
                        FormLogin.lc.updhistorymesin(tb_idmesin.Text, tb_idmesin.Text, tanggal, tb_perbaikan.Text, tb_biaya.Text, status)
                    End If
                Catch ex As OracleException
                    If ex.Number = 947 Then
                        MsgBox("Data Yang Dimasukkan Terlalu Panjang")
                    Else
                        MsgBox(ex.Message)
                    End If
                End Try
            End If
        Else
            MsgBox("Harap Isi Data Yang Kosong")
        End If
        loadulang()
        refreshTabel()
    End Sub

    Private Sub btn_update_Click(sender As Object, e As EventArgs) Handles btn_update.Click
        Dim tanggal As String
        Dim biaya As Integer
        biaya = CInt(Int(tb_biaya.Text))
        tanggal = DateTimePicker1.Value.ToString("dd-mm-yyyy")
        Try
            Dim iya As Integer = MessageBox.Show("Anda Yakin Update Data History Mesin " & tb_nama.Text & "?", "Konfirmasi", MessageBoxButtons.YesNo)
            If iya = DialogResult.Yes Then
                FormLogin.lc.uphistorymesin(tb_idmesin.Text, tb_idmesin.Text, tb_masalah.Text, tb_perbaikan.Text, biaya)
            End If
        Catch ex As OracleException
            If ex.Number = 947 Then
                MsgBox("Data Yang Dimasukkan Terlalu Panjang")
            Else
                MsgBox(ex.Message)
            End If
        End Try
    End Sub
End Class