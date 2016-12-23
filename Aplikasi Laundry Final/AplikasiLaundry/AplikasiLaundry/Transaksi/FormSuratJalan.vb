Public Class FormSuratJalan

    Private Sub FormSuratJalan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        generate()
    End Sub

    Private Sub generate()
        Dim id As String = "SJ"
        Dim i As Integer
        Dim rnd As New Random
        i = rnd.Next(999)
        id += i.ToString
        tb_idsuratjalan.Text = id
    End Sub

    Private Sub FormSuratJalan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
    End Sub

    Private Sub Cetak_Button_Click(sender As Object, e As EventArgs) Handles Cetak_Button.Click
        If FormUtama.IsOpen("ReportSuratJalan") = False Then
            Dim frm As New ReportSuratJalan
            Dim sj As New SuratJalan
            sj.Refresh()
            frm.MdiParent = FormUtama
            sj.SetDatabaseLogon(FormLogin.tb_username.Text, FormLogin.tb_password.Text)
            sj.SetParameterValue("nosuratjalan", tb_idsuratjalan.Text)
            sj.SetParameterValue("namapegawai", tb_namapetugas.Text)
            sj.SetParameterValue("tanggalkirim", DateTimePicker1.Value)
            sj.SetParameterValue("detailbarang", rtb_detailbrg.Text)
            sj.SetParameterValue("createdby", FormLogin.tb_username.Text)
            frm.CrystalReportViewer1.ReportSource = sj
            frm.Show()
            FormUtama.ChildNumber += 1
        End If
        'MsgBox(tb_idsuratjalan.Text)
        'MsgBox(tb_namapetugas.Text)
        'MsgBox(rtb_detailbrg.Text)
        Me.Dispose()
    End Sub

    Private Sub Reset_Button_Click(sender As Object, e As EventArgs) Handles Reset_Button.Click
        tb_idsuratjalan.Clear()
        tb_namapetugas.Clear()
        rtb_detailbrg.Clear()
    End Sub
End Class