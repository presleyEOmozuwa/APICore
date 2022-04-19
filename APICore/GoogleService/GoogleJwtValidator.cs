using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APICore.ModelService;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace APICore.GoogleService
{
    public class GoogleJwtValidator : IGoogleJwtValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly GoogleAuthSettings _googleAuthSettings;
        public GoogleJwtValidator(UserManager<ApplicationUser> userManager, IOptions<GoogleAuthSettings> googleAuthSettings)
        {
            _userManager = userManager;
            _googleAuthSettings = googleAuthSettings.Value;

        }

        public async Task<GoogleJsonWebSignature.Payload> VerifyGoogleToken(GoogleCredentials creds)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings()
                {
                    Audience = new List<string>() { _googleAuthSettings.ClientId }
                };
                var payload = await GoogleJsonWebSignature.ValidateAsync(creds.IdToken, settings);
                return payload;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Description {ex.Message}");
                Console.WriteLine($"Error Description {ex.Source}");
                Console.WriteLine($"Error Description {ex.StackTrace}");
                return null;
            }
        }

    }
}
