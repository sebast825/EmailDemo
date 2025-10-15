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
        public string HtmlBody { get; set; }
        public EmailTemplateContent(string subject, string HtmlBody)
        {
            Subject = subject;
            HtmlBody = HtmlBody;
        }
    }
}
