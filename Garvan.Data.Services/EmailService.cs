using Garvan.Core.Extensions;
using Garvan.Data.Interfaces;
using Garvan.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Garvan.Data.Services
{
    public class EmailService : IEmailService
    {
        IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmail(EmailToSend emailToSend)
        {
            var smtpConfigurationSection = _configuration.GetSection("SMTPSettings");
            var smtpAddress = smtpConfigurationSection.GetSection("Address").Value;
            var smtpUsername = smtpConfigurationSection.GetSection("Username").Value;
            var smtpPassword = smtpConfigurationSection.GetSection("Password").Value;
            var smtpPort = smtpConfigurationSection.GetSection("Port").Value.ConvertString<int>();
            var smtpEnableSSL = smtpConfigurationSection.GetSection("UseSSL").Value.ConvertString<bool>();
            var receiverEmail = smtpConfigurationSection.GetSection("ReceivingEmail").Value;

            using (var client = new SmtpClient(smtpAddress))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
                client.Port = smtpPort;
                client.EnableSsl = smtpEnableSSL;

                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(emailToSend.Email);
                    mailMessage.To.Add(receiverEmail);
                    mailMessage.Body = emailToSend.Message;
                    mailMessage.Subject = emailToSend.Subject;
                    await client.SendMailAsync(mailMessage);
                }
            }
        }
    }
}
