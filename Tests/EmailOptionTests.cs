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
        public void Welcome_WhenValidConfiguration_ShouldCallSendEmailAsync()
        {
            string emailReciver = "test@gmail.com";
            _emailOption.Welcome(emailReciver);

            _mockEmailSender.Verify(s => s.SendEmailAsync(emailReciver,EmailTemplatesOptions.Welcome.Subject,EmailTemplatesOptions.Welcome.HtmlBody), Times.Once);  
        }
    }
}
