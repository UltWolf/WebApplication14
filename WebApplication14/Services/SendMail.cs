using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication14.Services
{
    public class SendMail
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            //var emailMessage = new MimeMessage();

            //emailMessage.From.Add(new MailboxAddress("Администрация Магазина", "ultwolf@gmail.com"));
            //emailMessage.To.Add(new MailboxAddress("", email));
            //emailMessage.Subject = subject;
            //emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            //{
            //    Text = message
            //};

            //using (var client = new SmtpClient())
            //{
            //    await client.ConnectAsync("smtp.gmail.com", 587, false);
            //    await client.AuthenticateAsync("ultwolf@gmail.com", "Vetal230398");
            //    await client.SendAsync(emailMessage);

            //    await client.DisconnectAsync(true);
            //}
        }

    }
}
