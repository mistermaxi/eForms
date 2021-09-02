using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static eForms.Services.Interfaces.EmailService;

namespace eForms.Services.Interfaces
{
    public interface IEmailService
    {
        public int SendEmail(EmailModel emailModel);
    }
}
