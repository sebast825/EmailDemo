using Core.Entities;
using Core.Interface;
using Core.Templates;
using EmailServices;
using Moq;

namespace Tests
{
    [TestClass]
    public class EmailOptionTests
    {
        private  IEmailOption _emailOption;
        private Mock<IEmailSender> _mockEmailSender;
        [TestInitialize]
        public void SetUp () { 
            _mockEmailSender = new Mock<IEmailSender> ();
            _emailOption = new EmailOption(_mockEmailSender.Object);
        }

        [TestMethod]
        public async Task Welcome_WhenValidConfiguration_ShouldCallSendEmailAsync()
        {
            string emailReciver = "test@gmail.com";

            await _emailOption.Welcome(emailReciver);

            _mockEmailSender.Verify(s => s.SendEmailAsync(emailReciver,EmailTemplatesOptions.Welcome.Subject,EmailTemplatesOptions.Welcome.HtmlBody), Times.Once);  
        }

        [TestMethod]
        public async Task SendUserNotificationAsync_WhenValidConfiguration_ShouldCallSendEmailAsync()
        {
            string emailReciver = "test@gmail.com";
            string userName = "username";
            string message = "message";
            await _emailOption.SendUserNotificationAsync(emailReciver, userName, message);
            EmailTemplateContent notification = EmailTemplatesOptions.Notifiaction(userName, message);

            _mockEmailSender.Verify(s => s.SendEmailAsync(emailReciver, notification.Subject, notification.HtmlBody), Times.Once);
        }
    }
}
