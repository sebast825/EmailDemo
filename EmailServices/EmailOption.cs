using Core.Entities;
using Core.Interface;
using Core.Templates;


namespace EmailServices
{

    public class EmailOption : EmailOptionI
    {
        private readonly SmtpSender _smtpSender;
        public EmailOption(SmtpSender smtpSender) {
            _smtpSender = smtpSender;
        }
        

        public async Task Welcome(string to)
        {
            string subject = EmailTemplatesOptions.Welcome.Subject;
            string htmlBody = EmailTemplatesOptions.Welcome.Body;

            await _smtpSender.SendEmailAsync(to, subject, htmlBody);
        }

        public async Task Notification(string to,string userName,string message)
        {
            EmailTemplateContent notification =  EmailTemplatesOptions.Notifiaction(userName, message);
            string subject = notification.Subject;
            string htmlBody = notification.Body;

            await _smtpSender.SendEmailAsync(to, subject, htmlBody);
        }

    
    }
}