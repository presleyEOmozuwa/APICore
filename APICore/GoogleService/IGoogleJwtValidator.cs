using System;
using System.Threading.Tasks;
using APICore.ModelService;
using Google.Apis.Auth;

namespace APICore.GoogleService
{
    public interface IGoogleJwtValidator
    {
        Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(GoogleCredentials creds);
    }
}
