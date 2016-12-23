Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ReportSuratJalan
    Public nosuratjalan As String
    Public namapetugas As String
    Public tglkirim As String
    Public detailbarang As String
    Private Sub ReportSuratJalan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim rpt As New ReportDocument
        'rpt.Load("..\..\Report\SuratJalan.rpt")

        ''MsgBox(NewLaundry.kodeTrans)
        ''MsgBox("subtotal : " & subtotal & vbNewLine & "diskon : " & diskon & vbNewLine & "kembali : " & kembali)
        'rpt.SetDatabaseLogon(FormLogin.tb_username.Text, FormLogin.tb_password.Text)
        'rpt.SetParameterValue("nosuratjalan", FormSuratJalan.tb_idsuratjalan.Text)
        'rpt.SetParameterValue("namapegawai", FormSuratJalan.tb_namapetugas.Text)
        'rpt.SetParameterValue("tanggalkirim", FormSuratJalan.DateTimePicker1.Value)
        'rpt.SetParameterValue("detailbarang", FormSuratJalan.rtb_detailbrg.Text)
        'rpt.SetParameterValue("createdby", FormLogin.tb_username.Text)
        'CrystalReportViewer1.ReportSource = rpt
        'CrystalReportViewer1.Refresh()
    End Sub

    Private Sub ReportSuratJalan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
        FormSuratJalan.Show()
    End Sub
End Class