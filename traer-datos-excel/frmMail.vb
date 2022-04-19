Public Class frmMail
    Private Sub btnEnviar_Click(sender As Object, e As EventArgs) Handles btnEnviar.Click
        'enviarCorreo(ByVal emisor As String, password As String, mensaje As String, asunto As String, destinatario As String)
        enviarCorreo(txtEmisor.Text, txtPassword.Text, rtbMensaje.Text, txtAsunto.Text, txtReseptor.Text)
    End Sub
End Class