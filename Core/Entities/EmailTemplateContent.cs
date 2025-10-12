using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class EmailTemplateContent
    {

        public string Subject { get; set; }
        public string Body { get; set; }
        public EmailTemplateContent(string subject, string body)
        {
            Subject = subject;
            Body = body;
        }
    }
}
