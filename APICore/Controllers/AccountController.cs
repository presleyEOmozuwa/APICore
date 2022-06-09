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
using APICore.Repository;
using System.IO;
using APICore.DataModelService;
using APICore.DataInterfaces;

namespace APICore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
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



        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signManager, RoleManager<IdentityRole> roleManager, IOptions<AppSettings> appConfig, IJWtokenGenerator jwtokenGenerator, IHttpContextAccessor accessor, IEmailSvc emailSvc, IGoogleJwtValidator googleJwtValidator, IOptions<GoogleAuthSettings> googleSettings, ISubscriptionRepository subscriberRepository)
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

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if (!ModelState.IsValid || model == null)
            {
                return BadRequest();
            }

            //if (!await _roleManager.RoleExistsAsync(model.Role))
            //{
            //    await _roleManager.CreateAsync(new IdentityRole(model.Role));
            //}


            ApplicationUser appUser = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.UserName
            };

            var result = await _userManager.CreateAsync(appUser, model.Password);

            if (result.Succeeded)
            {
                var userFromDb = await _userManager.FindByEmailAsync(appUser.Email);

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(userFromDb);

                string clientUrl = "http://localhost:4200/settings/confirmemail";

                Dictionary<string, string> keyValues = new Dictionary<string, string>()
                {
                    {"token", token },
                    {"id",  userFromDb.Id}
                };

                string callBackUrl = QueryHelpers.AddQueryString(clientUrl, keyValues);

                var emailRequest = new EmailRequest()
                {
                    CallBackUrl = callBackUrl,
                    ToEmail = userFromDb.Email,
                    ToName = $"{userFromDb.FirstName} {userFromDb.LastName}",
                    Subject = "Email Confirmation Mail",
                    Attachments = null
                };

                await _emailSvc.SendEmailAsync(emailRequest);

                //await _userManager.AddToRoleAsync(userFromDb, model.Role);

                //var claim = new Claim("JobTitle", model.JobTitle);

                //await _userManager.AddClaimAsync(userFromDb, claim);

                return Ok(new RegisterResponse() { Message = "Registration Completed", IsRegistered = true });

            }

            return BadRequest(new RegisterResponse() { Message = "Registration Failed", IsRegistered = false });
        }


        [HttpPost("login")]
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
                return BadRequest(new { message = "Login failed" });
            }

            if (model.RememberMe)
            {
                _appConfig.TokenExpiry = "48";
            }

            var subscriber = await _subscriberRepository.GetByCustomerIdAsync(user.CustomerId);

            DateTime expDate;
            bool isSubscriber;

            if (subscriber != null && subscriber.Status == "active")
            {
                expDate = subscriber.CurrentPeriodEnd;
                isSubscriber = true;
            }
            else
            {
                expDate = DateTime.Now.AddDays(7);
                isSubscriber = true;
            }

            return Ok(new { token = _jwtokenGenerator.GenerateToken(user), isSubscriber, expDate });
        }

        [HttpPost("confirmemail")]
        public async Task<IActionResult> ConfirmEmail([FromBody] ConfirmEmailModel req)
        {
            var user = await _userManager.FindByIdAsync(req.Id);

            if (user == null)
            {
                return BadRequest();
            }

            var result = await _userManager.ConfirmEmailAsync(user, req.Token);

            if (result.Succeeded)
            {
                return Ok(new EmailConfirmationResponse() { Message = "Email Confirmation Successful", IsEmailConfirmed = true });
            }

            return BadRequest(new EmailConfirmationResponse() { Message = "Email Confirmation Failed", IsEmailConfirmed = false });
        }

    }
}