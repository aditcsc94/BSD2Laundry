Public Class LaporanPerTanggal

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If FormUtama.IsOpen("FormTransTanggal") = False Then
            Dim frm As New FormTransTanggal
            frm.MdiParent = FormUtama
            frm.Show()
            FormUtama.ChildNumber += 1
        End If
        Me.Dispose()
    End Sub

    Private Sub LaporanPerTanggal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
    End Sub

    Private Sub LaporanPerTanggal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class