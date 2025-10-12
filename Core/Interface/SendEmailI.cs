using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface SendEmailI
    {
        Task SendEmailAsync(string to, string subject, string htmlBody);

    }
}
