using LightScience.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace LightScience.Services
{
    public class EmailService
    {
        private readonly IOptions<EmailSettings> _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings; 
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            using (var client = new SmtpClient(_emailSettings.Value.MailServer, _emailSettings.Value.MailPort))
            {
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_emailSettings.Value.Username, _emailSettings.Value.Password);
                client.EnableSsl = true;

                using (var emailMessage = new MailMessage())
                {
                    emailMessage.To.Add(new MailAddress(email));
                    emailMessage.From = new MailAddress(_emailSettings.Value.SenderEmail);
                    emailMessage.Subject = subject;
                    emailMessage.Body = message;
                    await client.SendMailAsync(emailMessage);
                }
            }
        }
    }
}
