using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using APICore.EmailService;
using APICore.ModelService;
using APICore.TokenService;
using APICore.GoogleService;
using APICore.DataInterfaces;

namespace APICore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExternalController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppSettings _appConfig;
        private readonly IJWtokenGenerator _jwtokenGenerator;
        private readonly IHttpContextAccessor _accessor;
        private readonly IEmailSvc _emailSvc;
        private readonly IGoogleJwtValidator _googleJwtValidator;
        private readonly GoogleAuthSettings _googleSettings;
        private readonly ISubscriptionRepository _subscriberRepository;



        public ExternalController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signManager, RoleManager<IdentityRole> roleManager, IOptions<AppSettings> appConfig, IJWtokenGenerator jwtokenGenerator, IHttpContextAccessor accessor, IEmailSvc emailSvc, IGoogleJwtValidator googleJwtValidator, IOptions<GoogleAuthSettings> googleSettings, ISubscriptionRepository subscriberRepository)
        {
            _userManager = userManager;
            _signManager = signManager;
            _roleManager = roleManager;
            _appConfig = appConfig.Value;
            _jwtokenGenerator = jwtokenGenerator;
            _accessor = accessor;
            _emailSvc = emailSvc;
            _googleJwtValidator = googleJwtValidator;
            _googleSettings = googleSettings.Value;
            _subscriberRepository = subscriberRepository;

        }

        [HttpPost("externalLogger")]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLogin([FromBody] GoogleCredentials creds)
        {
            var payload = await _googleJwtValidator.VerifyGoogleToken(creds);

            if (payload == null)
            {
                return BadRequest(new { IsAuthenticated = false, Message = " Authentication Failed" });
            }
            else
            {
                var info = new UserLoginInfo(creds.Provider, payload.Subject, creds.Provider);
                var user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

                if (user == null)
                {
                    user = await _userManager.FindByEmailAsync(payload.Email);

                    if (user == null)
                    {
                        user = new ApplicationUser() { FirstName = "Guest", LastName = "Google", Email = payload.Email, UserName = payload.Email };
                        await _userManager.CreateAsync(user);
                        await _userManager.AddLoginAsync(user, info);

                        var response = await _subscriberRepository.MockUp(user);
                        response.IsExternalLogger = true;
                        response.Message = "No account, no extacc";
                        return Ok(new { token = _jwtokenGenerator.GenerateToken(user), Response = response });
                    }
                    else
                    {
                        await _userManager.AddLoginAsync(user, info);
                        var response = await _subscriberRepository.MockUp(user);
                        response.IsExternalLogger = true;
                        response.Message = "Has account, no extacc";
                        return Ok(new { token = _jwtokenGenerator.GenerateToken(user), Response = response });
                    }

                }
                else
                {
                    var response = await _subscriberRepository.MockUp(user);
                    response.IsExternalLogger = true;
                    response.Message = "Has account, has extacc";
                    return Ok(new { token = _jwtokenGenerator.GenerateToken(user), Response = response });
                }
            }
        }
    }
}