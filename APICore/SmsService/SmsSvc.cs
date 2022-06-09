using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using APICore.ModelService;
using Microsoft.Extensions.Options;
using Twilio.Clients;

namespace APICore.SmsService
{
    public class SmsSvc : ISmsSvc
    {
        private readonly TwilioSettings _twilioSettings;
        public SmsSvc(IOptions<TwilioSettings> twilioSettings)
        {
            _twilioSettings = twilioSettings.Value;
        }

        public async Task SendSmsAsync(SmsRequest request)
        {
            using (var client = new HttpClient() { BaseAddress = new Uri(_twilioSettings.BaseUrl) })
            {
                request.ToPhoneNumber = request.ToPhoneNumber.Trim();

                if (request.ToPhoneNumber.StartsWith("+"))
                {
                    request.ToPhoneNumber = request.ToPhoneNumber.Substring(1);
                }

                var basicHeaderValue = $"{_twilioSettings.AccountSID}:{_twilioSettings.AuthToken}";
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(basicHeaderValue)));

                var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    ["To"] = $"+{request.ToPhoneNumber}",
                    ["From"] = _twilioSettings.FromPhoneNumber,
                    ["Body"] = request.Message
                });

                var response = await client.PostAsync(_twilioSettings.RequestUrl, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("An error occurred while sending the SMS");
                }
            }
        }

    }
}
