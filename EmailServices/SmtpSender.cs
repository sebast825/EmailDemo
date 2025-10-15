using Core.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailServices
{
    public class SmtpSender : EmailSenderI
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
                string emailOrigen = _configuration["SmtpSettings:EmailOrigen"];
                string contrasenia = _configuration["SmtpSettings:Contrasenia"];
                string url = $"http://localhost:3000/recuperarClave/?token=";

                MailMessage mailMessage = new MailMessage(emailOrigen, to, subject, htmlBody);

                mailMessage.IsBodyHtml = true;

                using SmtpClient smtpClient = new SmtpClient
                {
                    Host = _configuration["SmtpSettings:SmtpHost"]!,
                    Port = int.Parse(_configuration["SmtpSettings:SmtpPort"]!),
                    EnableSsl = bool.Parse(_configuration["SmtpSettings:EnableSsl"]!),
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
