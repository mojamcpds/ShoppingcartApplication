using Shoppingcart.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Shoppingcart.Infrastructure.Email
{
    public class SMTPService : IEmailService
    {
        public void SendMail(string from, string to, string subject, string body)
        {

            MailMessage message = new MailMessage();

            message.From = new MailAddress(from);
            message.To.Add(new MailAddress(to));
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            message.Priority = MailPriority.Normal;
            
            string userName = ApplicationSettingsFactory.GetApplicationSettings().EmailAddress;
            string password = ApplicationSettingsFactory.GetApplicationSettings().Credential;


            SmtpClient smtp = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            smtp.Credentials = new NetworkCredential(userName, password);
            smtp.EnableSsl = true;
            smtp.Send(message);

        }
    }

}
