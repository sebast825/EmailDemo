

using Core.Interface;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Runtime.CompilerServices;


namespace EmailServices
{

    public class SmtpService : EmailOptions
    {
        private readonly IConfiguration _configuration;
        public SmtpService(IConfiguration configuration) {
            _configuration = configuration;
        }
        private async Task SendEmailAsync(string to, string subject, string htmlBody)
        {
            try
            {
                string emailOrigen = _configuration["CorreoSettings:EmailOrigen"];
                string contrasenia = _configuration["CorreoSettings:Contrasenia"];
                string url = $"http://localhost:3000/recuperarClave/?token=";

                MailMessage mailMessage = new MailMessage(emailOrigen, to, subject,subject);

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

        public async Task HelloEmailSend(string to)
        {
            string subject = "Bienvenido!";
            string htmlBody = "<p>¡Bienvenido a nuestro sitio! Explora y descubre todo lo que ofrecemos.</p>";

            await SendEmailAsync(to, subject, htmlBody);
        }
    }
}