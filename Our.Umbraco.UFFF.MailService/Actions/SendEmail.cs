using Our.Umbraco.Ufff.Core.Attributes;
using Our.Umbraco.Ufff.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Our.Umbraco.UFFF.MailService.Actions
{
    [Connector("Email", "Send")]
    public class SendEmail : IAction
    {
        public string From { get; set; }
        public string To { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }

        public void Run()
        {
            using(var smtp = new SmtpClient())
            {
                var msg = new MailMessage(From, To, Subject, Body);
                smtp.SendAsync(msg, null);
            }            
        }
    }
}
