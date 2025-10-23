using EmailServices;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class PostmarkSenderIntegrationTests
    {
        private PostmarkSender _postmarkSender;
        private IConfiguration _configuration;
        [TestInitialize]
        public void SetUp()
        {
            _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Test.json")
            .Build();

            _postmarkSender = new PostmarkSender(_configuration);

        }
        [TestMethod]
        public async Task SendEmailAsync_WhenValidCredentials_SendEmailAsync()
        {
            string to = _configuration["EmailSettings:DefaultRecipient"];
            string subjet = _configuration["EmailSettings:DefaultSubject"];
            string body = _configuration["EmailSettings:DefaultHtmlBody"];
            await _postmarkSender.SendEmailAsync(to, subjet, body);
            Assert.IsTrue(true);
        }
        [TestMethod]
        public async Task SendEmailAsync_WhenEmptyRecipient_ShouldThrowPostmarkValidationException()
        {
            string to = "";
            string subjet = _configuration["EmailSettings:DefaultSubject"];
            string body = _configuration["EmailSettings:DefaultHtmlBody"];
            var ex = await Assert.ThrowsExactlyAsync<PostmarkDotNet.Exceptions.PostmarkValidationException>(()=>   _postmarkSender.SendEmailAsync(to, subjet, body));
        }
    }
}
