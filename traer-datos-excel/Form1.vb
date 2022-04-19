Public Class Form1
    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        importarExcel(DataGridView1)
    End Sub

    Private Sub btnForm2_Click(sender As Object, e As EventArgs) Handles btnForm2.Click
        Dim miForm2 = New frmDatos_excel
        miForm2.ShowDialog()
    End Sub

    Private Sub btnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        frmMail.ShowDialog()
    End Sub


End Class
