

using Core.Interface;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Runtime.CompilerServices;


namespace EmailServices
{

    public class SmtpService : SendEmailI
    {
        private readonly IConfiguration _configuration;
        public SmtpService(IConfiguration configuration) {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string to, string subject, string htmlBody)
        {
            try
            {
                string emailOrigen = _configuration["CorreoSettings:EmailOrigen"];
                string contrasenia = _configuration["CorreoSettings:Contrasenia"];
                string url = $"http://localhost:3000/recuperarClave/?token=";

                MailMessage mailMessage = new MailMessage(emailOrigen, to, "Recuperación de Contraseña",
                    $"<p>Hemos recibido una solicitud para restablecer la contraseña de tu cuenta. Si fuiste tú quien solicitó este cambio, haz clic en el siguiente enlace:</p>" +
                    $"<a href='{url}'>Recuperar contraseña</a>" +
                    "<p>Si no solicitaste este cambio, ignora este correo.</p>" +
                    "<p>Saludos, Clinica Horizonte Demo</p>");

                mailMessage.IsBodyHtml = true;

                using SmtpClient smtpClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(emailOrigen, contrasenia)
                };

                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error enviando email: {ex.Message}");
            }
        }
    }
}