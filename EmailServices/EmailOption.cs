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
        

        public async Task HelloEmailSend(string to)
        {
            string subject = EmailTemplatesOptions.Welcome.Subject;
            string htmlBody = EmailTemplatesOptions.Welcome.Body;

            await _smtpSender.SendEmailAsync(to, subject, htmlBody);
        }
    }
}