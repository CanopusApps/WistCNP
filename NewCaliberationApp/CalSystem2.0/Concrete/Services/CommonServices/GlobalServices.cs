using System;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CalSystem2._0.Concrete.Services.CommonServices
{
    public class GlobalServices
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<GlobalServices> _logger;

        public GlobalServices(IConfiguration configuration, ILogger<GlobalServices> logger)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<string> SendEmailAsync(string csvContent, string recipientEmail, bool isForgot, string password)
        {
            var mailHost = _configuration["Email:MailHost"] ?? throw new InvalidOperationException("MailHost configuration is missing.");
            var fromEmail = _configuration["Email:FromEmail"] ?? throw new InvalidOperationException("FromEmail configuration is missing.");

            string subject;
            string body;

            try
            {
                using var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    IsBodyHtml = true
                };

                if (!string.IsNullOrEmpty(csvContent))
                {
                    subject = "Calibration Report";
                    body = "Please find attached the calibration report.";

                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.To.Add(recipientEmail);

                    byte[] csvBytes = Encoding.UTF8.GetBytes(csvContent);
                    using var ms = new MemoryStream(csvBytes);
                    var mailAttachment = new Attachment(ms, "PendingCal.csv", "text/csv");
                    mailMessage.Attachments.Add(mailAttachment);

                    await SendMailAsync(mailHost, mailMessage);
                }
                else if (isForgot)
                {
                    subject = "Password Recovery Mail";
                    body = $"Your password is: {password}";

                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.To.Add(recipientEmail);

                    await SendMailAsync(mailHost, mailMessage);
                }
                else
                {
                    return "No content to send.";
                }

                return $"Email sent successfully to {recipientEmail}";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email to {RecipientEmail}", recipientEmail);
                return $"Error sending email to {recipientEmail}: {ex.Message}";
            }
        }

        private async Task SendMailAsync(string mailHost, MailMessage mailMessage)
        {
            using var smtpClient = new SmtpClient(mailHost);
            await smtpClient.SendMailAsync(mailMessage);
        }


    }
}
