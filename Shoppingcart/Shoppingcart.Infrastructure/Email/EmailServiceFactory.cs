using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shoppingcart.Infrastructure.Email
{
    public class EmailServiceFactory
    {
        private static IEmailService _emailService;

        public static void InitializeEmailServiceFactory(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public static IEmailService GetEmailService()
        {
            return _emailService;
        }
    }

}
