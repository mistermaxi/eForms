using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using ContentDisposition = System.Net.Mime.ContentDisposition;
using eForms.Services.Interfaces;
using Microsoft.AspNetCore.Http;

namespace eForms.Pages
{
    public class SendMailModel : PageModel
    {
        private string _host;
        private string _port;
        private string _from;
        private string _alias;

        IEmailService emailService;

        public SendMailModel(IConfiguration iConfiguration, IEmailService _emailService)
        {
            var smtpSection = iConfiguration.GetSection("SMTP");
            if (smtpSection != null)
            {
                _host = smtpSection.GetSection("Host").Value;
                _port = smtpSection.GetSection("Port").Value;
                _from = smtpSection.GetSection("From").Value;
                _alias = smtpSection.GetSection("Alias").Value;
            }

            emailService = _emailService;
        }
        public void OnGet()
        {
            ViewData["EmailAddress"] = "";
        }
        public void OnPostSendMailKit()
        {
            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("from_address@example.com"));
            email.To.Add(MailboxAddress.Parse("to_address@example.com"));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = "<h1>Example HTML Message Body</h1>" };

            // send email
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("[USERNAME]", "[PASSWORD]");
            smtp.Send(email);
            smtp.Disconnect(true);
            //return Page();
        }
        public void OnPostSend(IFormCollection form)
        {
            // Create a message and set up the recipients.

            string mailfrom = "Max@state.gov";
            string mailto = form["mail"];
            string mailsubject = "This is mail from .net core";
            string mailbody = "Hello..test";

            //MailMessage message = new MailMessage(
            //    "Max@state.gov",
            //    "ben@contoso.com",
            //    "Quarterly data report.",
            //    "See the attached spreadsheet.");

            //---- Create  the file attachment for this email message.
            //Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
            //// Add time stamp information for the file.
            //ContentDisposition disposition = data.ContentDisposition;
            //disposition.CreationDate = System.IO.File.GetCreationTime(file);
            //disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            //disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            //---- Add the file attachment to this email message.
            //message.Attachments.Add(data);

            MailMessage message = new MailMessage(
               mailfrom,
               mailto,
               mailsubject,
               mailbody);

            MailAddress bcc = new MailAddress("webmasterbkk@state.gov", "Max@state.gov");
            message.Bcc.Add(bcc);
            //Set Email Message Priority.
            message.Priority = MailPriority.High;
            message.IsBodyHtml = true;
            //Send the message.
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("nccsmtprelay.irm.state.gov");
            // Add credentials if the SMTP server requires them.
            client.Credentials = CredentialCache.DefaultNetworkCredentials;
            client.Port = 25;
            
            try
            {
                client.Send(message);
                ViewData["EmailAddress"] = "Successfully sent to " + mailto;
            }
            catch (Exception ex)
            {
                ViewData["EmailAddress"] = "Send Email failed!";
            }

            //---- Display the values in the ContentDisposition for the attachment.
            //ContentDisposition cd = data.ContentDisposition;
            //Console.WriteLine("Content disposition");
            //Console.WriteLine(cd.ToString());
            //Console.WriteLine("File {0}", cd.FileName);
            //Console.WriteLine("Size {0}", cd.Size);
            //Console.WriteLine("Creation {0}", cd.CreationDate);
            //Console.WriteLine("Modification {0}", cd.ModificationDate);
            //Console.WriteLine("Read {0}", cd.ReadDate);
            //Console.WriteLine("Inline {0}", cd.Inline);
            //Console.WriteLine("Parameters: {0}", cd.Parameters.Count);
            //foreach (DictionaryEntry d in cd.Parameters)
            //{
            //    Console.WriteLine("{0} = {1}", d.Key, d.Value);
            //}
            //data.Dispose();

            //return Page();
        }
        
        public void OnPostSendEmailHelper()
        {
            var emailModel = new EmailService.EmailModel("Max@state.gov", // To  
                "Email Test", // Subject  
                "Sending Email using Asp.Net Core.", // Message  
                true // IsBodyHTML  
            );
            if (emailService.SendEmail(emailModel) == 0)
            {
                ViewData["EmailAddress"] = "SendEmailHelper failed!";
            }
            else
                ViewData["EmailAddress"] = "Successfully SendEmailHelper to " + emailModel.To;

            //return Page();
        }

        //public async Task SendEmailAsync(string mail, string subject, string htmlMessage)
        public async Task<IActionResult> OnPostAsync(IFormCollection form)
        {
            //string mailfrom = "Max@state.gov";
            string mailto = form["mail"];
            //string mailto = data.ma;
            string mailsubject = "This is mail from .net core";
            string mailbody = "<html><body>Hello..test<a href='#'>Link</a></body></html>";
            string host = _host;
            int port = Convert.ToInt32(_port);
            string fromAddress = _from;

            //MailMessage message = new MailMessage();
            ////message.Subject = subject;
            ////message.Body = htmlMessage;
            //message.Subject = mailsubject;
            //message.Body = mailbody;
            //message.IsBodyHtml = true;
            //message.To.Add(mailto);
            //message.From = new MailAddress(fromAddress);

            //-------- Code below is work for send email to Gmail
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("Max@state.gov");
                mail.To.Add(mailto);
                mail.Subject = mailsubject;
                mail.Body = mailbody;
                mail.IsBodyHtml = true;
                //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                using (System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("yosvaris@gmail.com", "M@xgmail");
                    smtp.EnableSsl = true;
                    try
                    {
                        await smtp.SendMailAsync(mail);
                        ViewData["EmailAddress"] = "GMAIL SMTP Successfully SendEmailAsync to " + mailto;
                    }
                    catch
                    {
                        ViewData["EmailAddress"] = "SendEmailAsync failed!";
                    }
                    
                }
            }

            return Page();
        }
        public static void CreateMessageWithAttachment(string server)
        {
            // Specify the file to be attached and sent.
            // This example assumes that a file named Data.xls exists in the
            // current working directory.
            string file = "data.xls";
            // Create a message and set up the recipients.
            MailMessage message = new MailMessage(
                "jane@contoso.com",
                "ben@contoso.com",
                "Quarterly data report.",
                "See the attached spreadsheet.");

            // Create  the file attachment for this email message.
            Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
            // Add time stamp information for the file.
            System.Net.Mime.ContentDisposition disposition = data.ContentDisposition;
            disposition.CreationDate = System.IO.File.GetCreationTime(file);
            disposition.ModificationDate = System.IO.File.GetLastWriteTime(file);
            disposition.ReadDate = System.IO.File.GetLastAccessTime(file);
            // Add the file attachment to this email message.
            message.Attachments.Add(data);

            //Send the message.
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(server);
            // Add credentials if the SMTP server requires them.
            client.Credentials = CredentialCache.DefaultNetworkCredentials;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateMessageWithAttachment(): {0}",
                    ex.ToString());
            }
            // Display the values in the ContentDisposition for the attachment.
            ContentDisposition cd = data.ContentDisposition;
            Console.WriteLine("Content disposition");
            Console.WriteLine(cd.ToString());
            Console.WriteLine("File {0}", cd.FileName);
            Console.WriteLine("Size {0}", cd.Size);
            Console.WriteLine("Creation {0}", cd.CreationDate);
            Console.WriteLine("Modification {0}", cd.ModificationDate);
            Console.WriteLine("Read {0}", cd.ReadDate);
            Console.WriteLine("Inline {0}", cd.Inline);
            Console.WriteLine("Parameters: {0}", cd.Parameters.Count);
            foreach (DictionaryEntry d in cd.Parameters)
            {
                Console.WriteLine("{0} = {1}", d.Key, d.Value);
            }
            data.Dispose();
        }
    }
}
