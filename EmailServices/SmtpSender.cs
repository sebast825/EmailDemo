using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailServices
{
    public class SmtpSender
    {
        private readonly IConfiguration _configuration;
        public SmtpSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string to, string subject, string htmlBody)
        {
            try
            {
                string emailOrigen = _configuration["CorreoSettings:EmailOrigen"];
                string contrasenia = _configuration["CorreoSettings:Contrasenia"];
                string url = $"http://localhost:3000/recuperarClave/?token=";

                MailMessage mailMessage = new MailMessage(emailOrigen, to, subject, htmlBody);

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
