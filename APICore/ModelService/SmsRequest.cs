using System;
namespace APICore.ModelService
{
    public class SmsRequest
    {
        public string ToPhoneNumber { get; set; }
        public string Message { get; set; }
    }
}
