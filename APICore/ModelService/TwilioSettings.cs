using System;
namespace APICore.ModelService
{
    public class TwilioSettings
    {
        public string AccountSID { get; set; }
        public string AuthToken { get; set; }
        public string FromPhoneNumber { get; set; }
        public string BaseUrl { get; set; }
        public string RequestUrl { get; set; }
    }
}
