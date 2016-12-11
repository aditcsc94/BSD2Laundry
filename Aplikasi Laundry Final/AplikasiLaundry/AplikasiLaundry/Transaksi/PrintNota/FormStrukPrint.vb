﻿Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FormStrukPrint
    Public subtotal, diskon, kembali As String
    Private Sub FormStrukPrint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rpt As New ReportDocument
        rpt.Load("..\..\Transaksi\PrintNota\PrintNota1.rpt")

        'MsgBox(NewLaundry.kodeTrans)
        'MsgBox("subtotal : " & subtotal & vbNewLine & "diskon : " & diskon & vbNewLine & "kembali : " & kembali)
        rpt.SetDatabaseLogon(FormLogin.tb_username.Text, FormLogin.tb_password.Text)
        rpt.SetParameterValue("paramkode", NewLaundry.kodeTrans)
        rpt.SetParameterValue("subtotal", subtotal)
        rpt.SetParameterValue("diskon", diskon)
        rpt.SetParameterValue("kembali", kembali)
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Refresh()
    End Sub
End Class