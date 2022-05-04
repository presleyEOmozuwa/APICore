using System;
using System.Threading.Tasks;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using APICore.ModelService;
using APICore.TokenService;
using APICore.GoogleService;
using APICore.DataInterfaces;

namespace APICore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginUserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signManager;
        private readonly IGoogleJwtValidator _googleJwtValidator;
        private readonly AppSettings _appConfig;
        private readonly GoogleAuthSettings _googleSettings;
        private readonly IJWtokenGenerator _jwtokenGenerator;
        private readonly ISubscriptionRepository _subscriberRepository;

        public LoginUserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signManager, IOptions<AppSettings> appConfig, IOptions<GoogleAuthSettings> googleSettings, IJWtokenGenerator jwtokenGenerator, IGoogleJwtValidator googleJwtValidator, ISubscriptionRepository subscriberRepository)
        {
            _userManager = userManager;
            _signManager = signManager;
            _appConfig = appConfig.Value;
            _googleSettings = googleSettings.Value;
            _jwtokenGenerator = jwtokenGenerator;
            _googleJwtValidator = googleJwtValidator;
            _subscriberRepository = subscriberRepository;

        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            if (model == null || !ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return BadRequest();
            }

            var result = await _signManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (!result.Succeeded)
            {
                return BadRequest(new { message = "Login failed", isAuthentication = false });
            }

            if (model.RememberMe)
            {
                _appConfig.TokenExpiry = "48";
            }

            var response = await _subscriberRepository.MockUp(user);
            response.IsExternalLogger = false;
            response.Message = "InHouse";
            return Ok(new { token = _jwtokenGenerator.GenerateToken(user), Response = response });
        }

    }
}