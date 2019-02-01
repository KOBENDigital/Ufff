using Our.Umbraco.Ufff.Core.Attributes;
using Our.Umbraco.Ufff.Core.Interfaces;
using Our.Umbraco.UFFF.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Our.Umbraco.UFFF.MailService.Actions
{
    [Connector("email", "Email", "send", "Send")]
    public class SendEmail : ActionBase
    {
        public override string Alias => "sendEmail";                
        public string From { get; set; }
        public string To { get; set; }

        public string Subject { get; set; }
        public string Body { get; set; }


        public override void Run()
        {
            using(var smtp = new SmtpClient())
            {
                var msg = new MailMessage(From, To, Subject, Body);
                smtp.SendAsync(msg, null);
            }            
        }
    }
}
