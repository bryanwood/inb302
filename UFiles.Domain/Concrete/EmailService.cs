using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using UFiles.Domain.Abstract;
namespace UFiles.Domain.Concrete
{
    public class EmailService : IEmailService
    {
        SmtpClient client;
        public EmailService()
        {
            client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            client.PickupDirectoryLocation = @"C:\emails\";
            
        }
        public void SendEmail(string[] recipients, string message){
            MailMessage msg = new MailMessage();
            foreach(var recipient in recipients){

            msg.To.Add(new MailAddress(recipient));
            }
            msg.From = new MailAddress("friendly-robot@bryanwood.com.au");
            msg.Subject = "Message from uFiles";
            msg.Body = message;
            client.Send(msg);
        }
    }
}
