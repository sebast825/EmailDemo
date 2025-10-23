using Castle.Core.Smtp;
using EmailServices;
using Microsoft.Extensions.Configuration;
using netDumbster.smtp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class SmtpSenderIntegrationTests
    {
        private static SimpleSmtpServer _smtpServer;
        private IConfiguration _configuration;
        private SmtpSender _smtpSender;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            // Inicializar el servidor SMTP fake una vez para todos los tests
            _smtpServer = SimpleSmtpServer.Start(587);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _smtpServer?.Stop();
            _smtpServer?.Dispose();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.Test.json")
            .AddInMemoryCollection(new Dictionary<string, string>
            {
                ["SmtpSettings:SmtpPort"] = _smtpServer.Configuration.Port.ToString()
            })
           .Build();
            _smtpSender = new SmtpSender(_configuration);

            // Clean emails recibed before each test
            _smtpServer.ClearReceivedEmail();
        }


        [TestMethod]
        public async Task SendEmailAsync_WithValidConfiguration_ShouldInitialize()
        {
            var to = _configuration["EmailSettings:DefaultRecipient"];
            string subjet = _configuration["EmailSettings:DefaultSubject"];
            string body = _configuration["EmailSettings:DefaultHtmlBody"];

            await _smtpSender.SendEmailAsync(to, subjet, body);


        }
        [TestMethod]
        public async Task SendEmailAsync_WithInvalidConfiguration_ShouldThrow()
        {
            var to = "";
            string subjet = _configuration["EmailSettings:DefaultSubject"];
            string body = _configuration["EmailSettings:DefaultHtmlBody"];

            var ex = await Assert.ThrowsAsync<Exception>(()=> _smtpSender.SendEmailAsync(to, subjet, body));


        }
    }
}