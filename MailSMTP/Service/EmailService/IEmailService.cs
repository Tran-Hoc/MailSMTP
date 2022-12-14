using MailSMTP.Models;

namespace MailSMTP.Service.EmailService
{
    public interface IEmailService
    {
        void SendEmail(EmailDTO request);
    }
}
