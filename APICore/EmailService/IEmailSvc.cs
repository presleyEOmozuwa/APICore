using System;
using System.Threading.Tasks;
using APICore.ModelService;

namespace APICore.EmailService
{
    public interface IEmailSvc
    {
        Task SendEmailAsync(EmailRequest emailRequest);
    }
}
