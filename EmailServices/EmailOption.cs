using Core.Entities;
using Core.Interface;
using Core.Templates;


namespace EmailServices
{

    public class EmailOption : IEmailOption
    {
        private readonly IEmailSender _emailSender;
        public EmailOption(IEmailSender emailSender) {
            _emailSender = emailSender;
        }
        
        public async Task Welcome(string to)
        {
            string subject = EmailTemplatesOptions.Welcome.Subject;
            string htmlBody = EmailTemplatesOptions.Welcome.HtmlBody;

            await _emailSender.SendEmailAsync(to, subject, htmlBody);
        }

        public async Task SendUserNotificationAsync(string to,string userName,string message)
        {
            EmailTemplateContent notification =  EmailTemplatesOptions.Notifiaction(userName, message);
            string subject = notification.Subject;
            string htmlBody = notification.HtmlBody;

            await _emailSender.SendEmailAsync(to, subject, htmlBody);
        }
    
    }
}