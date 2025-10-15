using Core.Interface;
using Microsoft.Extensions.Configuration;
using PostmarkDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailServices
{
    public class PostmarkSender : EmailSenderI
    {
       
            private readonly IConfiguration _configuration;

            public PostmarkSender(IConfiguration configuration)
            {
                _configuration = configuration;
            }

            public async Task SendEmailAsync(string to, string subject, string htmlBody)
            {
                // Send an email asynchronously:
                var message = new PostmarkMessage()
                {
                    To = to,
                    From = _configuration["PostmarkSettings:EmailOrigen"],
                    TrackOpens = true,
                    Subject = subject,
                    HtmlBody = htmlBody,
                    MessageStream = _configuration["PostmarkSettings:MessageStream"],
                    Tag = _configuration["PostmarkSettings:Tag"]

                };


                var client = new PostmarkClient(_configuration["PostmarkSettings:ApiKey"]);
                var sendResult = await client.SendMessageAsync(message);

                if (sendResult.Status == PostmarkStatus.Success) { /* Handle success */ }
                else { /* Resolve issue.*/ }
            }
        }
    
}
