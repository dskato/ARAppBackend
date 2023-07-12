using Azure;
using Azure.Communication.Email;
using Azure.Identity;
using System.Net.Mail;
using System.Net;

namespace ARAppBackend
{
    public partial class ApplicationService : IApplicationService
    {

        
        public async Task<string> SendPasswordRecoveryEmailAsync(string email) {

            string resetCode = GenerateRandomCode(6);
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {

                Port = 587,
                Credentials = new NetworkCredential("dskato0603@gmail.com", "tdmjfibhwoclozfq"),
                UseDefaultCredentials = false,
                EnableSsl = true,

            };

            var code = $"<p>Tu codigo de restablecimiento es: {resetCode}</p>";
            var htmlContent = "<html><body><h1>Restablecer Contraseña</h1><br/><h4>Use el siguiente codigo para restablecer la contraseña</h4>" + code + "</body></html>";

            var mailMessage = new MailMessage

            {

                From = new MailAddress("dskato0603@gmail.com"),
                Subject = "Restablecer Contraseña",
                Body = htmlContent,
                IsBodyHtml = true,

            };

            mailMessage.To.Add(email);

            smtpClient.Send(mailMessage);
            /*
            string resetCode = GenerateRandomCode(6);
            var comConenctionString = _configuration["ConnectionStrings:CommunicationConnection"];
            EmailClient emailClient = new EmailClient(comConenctionString);

            var subject = "Restablecer Contraseña";
            var code = $"<p>Tu codigo de restablecimiento es: {resetCode}</p>";
            var htmlContent = "<html><body><h1>Restablecer Contraseña</h1><br/><h4>Use el siguiente codigo para restablecer la contraseña</h4>"+code+"</body></html>";
            var sender = "donotreply@1e7d5d2f-a752-4e25-9b54-dc2cc6b22d94.azurecomm.net";
            var recipient = email;

            try
            {
                Console.WriteLine("Sending email...");
                EmailSendOperation emailSendOperation = await emailClient.SendAsync(
                    Azure.WaitUntil.Completed,
                    sender,
                    recipient,
                    subject,
                    htmlContent);
                EmailSendResult statusMonitor = emailSendOperation.Value;

                Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

                string operationId = emailSendOperation.Id;
                Console.WriteLine($"Email operation id = {operationId}");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
                resetCode = null;
            }
            */

            return resetCode;
        }

        private string GenerateRandomCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
