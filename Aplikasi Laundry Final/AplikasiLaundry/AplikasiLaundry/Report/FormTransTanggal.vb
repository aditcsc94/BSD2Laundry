Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FormTransTanggal

    Private Sub FormTransTanggal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rpt As New ReportDocument
        rpt.Load("..\..\Report\TransaksiPerTanggal.rpt")

        'MsgBox(NewLaundry.kodeTrans)
        'MsgBox("subtotal : " & subtotal & vbNewLine & "diskon : " & diskon & vbNewLine & "kembali : " & kembali)
        rpt.SetDatabaseLogon(FormLogin.tb_username.Text, FormLogin.tb_password.Text)
        rpt.SetParameterValue("awal", LaporanPerTanggal.DateTimePicker1.Value)
        rpt.SetParameterValue("akhir", LaporanPerTanggal.DateTimePicker2.Value)
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub FormTransTanggal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
        LaporanPerTanggal.Show()
    End Sub

    Private Sub TransaksiPerTanggal11_InitReport(sender As Object, e As EventArgs)

    End Sub
End Class