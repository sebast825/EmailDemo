using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IEmailOption
    {
        Task Welcome(string to);
        Task SendUserNotificationAsync(string to, string userName, string message);

    }
}
