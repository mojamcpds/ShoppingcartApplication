using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shoppingcart.Infrastructure.Email
{
    public interface IEmailService
    {
        void SendMail(string from, string to, string subject, string body);
    }
}
