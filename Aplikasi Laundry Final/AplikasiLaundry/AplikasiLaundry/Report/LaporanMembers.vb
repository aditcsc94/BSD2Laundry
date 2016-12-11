Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class LaporanMembers

    Private Sub LaporanMembers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rpt As New ReportDocument
        rpt.Load("..\..\Report\memberReport.rpt")

        'MsgBox(NewLaundry.kodeTrans)
        'MsgBox("subtotal : " & subtotal & vbNewLine & "diskon : " & diskon & vbNewLine & "kembali : " & kembali)
        rpt.SetDatabaseLogon(FormLogin.tb_username.Text, FormLogin.tb_password.Text)
        
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Refresh()
    End Sub

    Private Sub LaporanMembers_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
    End Sub
End Class