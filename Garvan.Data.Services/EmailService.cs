﻿using Garvan.Core.Extensions;
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
            var smtpAddress = _configuration.GetSection("SMTP_Address").Value;
            var smtpUsername = _configuration.GetSection("SMTP_Username").Value;
            var smtpPassword = _configuration.GetSection("SMTP_Password").Value;
            var smtpPort = _configuration.GetSection("SMTP_Port").Value.ConvertString<int>();
            var smtpEnableSSL = _configuration.GetSection("SMTP_UseSSL").Value.ConvertString<bool>();
            var receiverEmail = _configuration.GetSection("SMTP_ReceivingEmail").Value;

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
                    mailMessage.Body = $"You received email from '{emailToSend.Email}';<br/><br/><br/> Subject: {emailToSend.Subject}<br/><br/><br/> {emailToSend.Message}";
                    mailMessage.Subject = "Email from website form";
                    await client.SendMailAsync(mailMessage);
                }
            }
        }
    }
}
