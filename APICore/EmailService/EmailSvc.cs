using MailKit.Net.Smtp;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MimeKit;
using APICore.EmailService;
using APICore.ModelService;
using System.IO;
using MailKit.Security;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Identity;

namespace APICore.EmailService
{
    public class EmailSvc : IEmailSvc
    {
        private readonly EmailSettings _emailConfig;

        public EmailSvc(IOptions<EmailSettings> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }

        public async Task SendEmailAsync(EmailRequest emailRequest)
        {

            string filePath = $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}wwwroot{Path.DirectorySeparatorChar}EmailTemplates{Path.DirectorySeparatorChar}{emailRequest.EmailFilePath}";
            StreamReader str = new StreamReader(filePath);
            string MailText = str.ReadToEnd();
            str.Close();
            MailText = MailText.Replace("[callBackUrl]", emailRequest.CallBackUrl);
            MailText = MailText.Replace("[ToName]", emailRequest.ToName);
            MailText = MailText.Replace("[ToEmail]", emailRequest.ToEmail);

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailConfig.FromEmail));
            email.To.Add(new MailboxAddress(emailRequest.ToName, emailRequest.ToEmail));
            email.Subject = emailRequest.Subject;

            var builder = new BodyBuilder();

            if (emailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in emailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            builder.HtmlBody = MailText;
            email.Body = builder.ToMessageBody();


            using (var client = new SmtpClient())
            {
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.ConnectAsync(_emailConfig.Host, _emailConfig.Port, false);
                await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);
                await client.SendAsync(email);
                await client.DisconnectAsync(true);
            }
        }
    }
}