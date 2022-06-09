using System;
using System.Threading.Tasks;
using APICore.ModelService;

namespace APICore.SmsService
{
    public interface ISmsSvc
    {
        Task SendSmsAsync(SmsRequest request);
    }
}
