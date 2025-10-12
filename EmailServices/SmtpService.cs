

using Core.Interface;
using Microsoft.Extensions.Configuration;



namespace EmailServices
{

    public class SmtpService : EmailOptions
    {
        private readonly SmtpSender _smtpSender;
        public SmtpService(SmtpSender smtpSender) {
            _smtpSender = smtpSender;
        }
        

        public async Task HelloEmailSend(string to)
        {
            string subject = "Bienvenido!";
            string htmlBody = "<p>¡Bienvenido a nuestro sitio! Explora y descubre todo lo que ofrecemos.</p>";

            await _smtpSender.SendEmailAsync(to, subject, htmlBody);
        }
    }
}