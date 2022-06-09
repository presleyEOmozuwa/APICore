using System;
using System.Net;
using System.Threading.Tasks;
using Twilio;
using Twilio.Clients;
using Twilio.Http;

namespace APICore.TwilioClient
{
    public class TwilioRestClient : ITwilioRestClient
    {
        public TwilioRestClient()
        {
        }

        public string AccountSid => throw new NotImplementedException();

        public string Region => throw new NotImplementedException();

        public HttpClient HttpClient => throw new NotImplementedException();

        public Response Request(Request request)
        {
            throw new NotImplementedException();
        }

        public Task<Response> RequestAsync(Request request)
        {
            throw new NotImplementedException();
        }
    }
}
