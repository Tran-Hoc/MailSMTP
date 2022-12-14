using MailKit.Net.Smtp;
using MimeKit;

namespace MailSMTP.Service.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration= configuration;
        }
        public void SendEmail(EmailDTO request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("2001tranhoc@gmail.com"));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = request.Body
            };
            using var smtp = new SmtpClient();
            smtp.Connect(_configuration.GetSection("EmailHost").Value, 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_configuration.GetSection("EmailUserName").Value, _configuration.GetSection("EmailPassword").Value);
            smtp.Send(email);

            smtp.Disconnect(true);
        }
    }
}
