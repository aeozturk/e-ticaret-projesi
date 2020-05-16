using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using Service.EmailSender.Config;
using Service.EmailSender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service.EmailSender
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfig;

        public EmailService(IEmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public void SendEmail(string email, string subject, string emailBody, string userName, string userSurname)
        {
            List<EmailAddress> ToAddress = new List<EmailAddress>();//Kime
            List<EmailAddress> FromAddress = new List<EmailAddress>();//Gönderen


            ToAddress.Add(new EmailAddress { Name = userName + " " + userSurname, Adress = email });

            FromAddress.Add(new EmailAddress { Name = "Yağ Dünyası", Adress = "ae.ozturk93@gmail.com" });
            EmailMessage emailMessage = new EmailMessage
            {
                Subject = subject,
                ToAddresses = ToAddress,
                FromAddresses = FromAddress
            };

            SendEmailAsync(emailMessage, emailBody);
        }


        private async void SendEmailAsync(EmailMessage emailMessage, string emailBody)
        {
            var message = new MimeMessage();
            message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(name: x.Name, address: x.Adress)));
            message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(name: x.Name, address: x.Adress)));

            message.Subject = emailMessage.Subject;
            //We will say we are sending HTML. But there are options for plaintext etc.

            message.Body = new TextPart(TextFormat.Html)
            {
                Text = emailBody
            };

            try
            {
                //Be careful that the SmtpClient class is the one from Mailkit not the framework!
                using (var emailClient = new SmtpClient())
                {
                    //Remove any OAuth functionality as we won't be using it. 
                    emailClient.AuthenticationMechanisms.Remove("XOAUTH2");

                    //The last parameter here is to use SSL (Which you should!)
                    await emailClient.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.SmtpPort, false);
                    await emailClient.AuthenticateAsync(_emailConfig.SmtpUsername, _emailConfig.SmtpPassword);
                    await emailClient.SendAsync(message);
                    await emailClient.DisconnectAsync(true);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
