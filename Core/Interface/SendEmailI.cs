using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface SendEmailI
    {
        Task SendAsync(string to, string subject, string htmlBody);

    }
}
