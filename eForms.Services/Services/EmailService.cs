using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Text;


namespace eForms.Services.Interfaces
{
    public class EmailService : IEmailService
    {

        private string _host;
        private string _port;
        private string _from;
        private string _alias;

        public EmailService(IConfiguration iConfiguration)
        {
            var smtpSection = iConfiguration.GetSection("SMTP");
            if (smtpSection != null)
            {
                _host = smtpSection.GetSection("Host").Value;
                _port = smtpSection.GetSection("Post").Value;
                _from = smtpSection.GetSection("From").Value;
                _alias = smtpSection.GetSection("Alias").Value;
            }
        }

        public class EmailModel
        {
            public EmailModel(string to, string subject, string message, bool isBodyHtml)
            {
                To = to;
                Subject = subject;
                Message = message;
                IsBodyHtml = isBodyHtml;
            }
            public string To
            {
                get;
            }
            public string Subject
            {
                get;
            }
            public string Message
            {
                get;
            }
            public bool IsBodyHtml
            {
                get;
            }
        }
        public int SendEmail(EmailModel emailModel)
        {
            try
            {
                using (SmtpClient client = new SmtpClient(_host))
                {
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress(_from, _alias);
                    mailMessage.BodyEncoding = Encoding.UTF8;
                    mailMessage.To.Add(emailModel.To);
                    mailMessage.Body = emailModel.Message;
                    mailMessage.Subject = emailModel.Subject;
                    mailMessage.IsBodyHtml = emailModel.IsBodyHtml;
                    client.Send(mailMessage);
                    return 1;
                }
            }
            catch
            {
                //throw;
                return 0;
            }
        }
    }
}