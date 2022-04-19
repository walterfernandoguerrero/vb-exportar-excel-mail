Imports System.Net
Imports System.Net.Mail
Module Correo

    Private correos As New MailMessage
    Private envios As New SmtpClient

    Sub enviarCorreo(ByVal emisor As String, password As String, mensaje As String, asunto As String, destinatario As String)
        Try
            correos.To.Clear()
            correos.Body = ""
            correos.Subject = ""
            correos.Body = mensaje
            correos.Subject = asunto
            correos.IsBodyHtml = True
            'trim saca espacios en blanco
            correos.To.Add(Trim(destinatario))

            correos.From = New MailAddress(emisor)
            envios.Credentials = New NetworkCredential(emisor, password)

            'datos de conofiguracion de programa no se tocan

            envios.Host = "smtp.live.com"
            envios.Port = 587
            envios.EnableSsl = True

            envios.Send(correos)
            MsgBox("mensaje enviado ", MsgBoxStyle.Information, "MENSAJE")



        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensajeria 1.0 vb.netº", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module
