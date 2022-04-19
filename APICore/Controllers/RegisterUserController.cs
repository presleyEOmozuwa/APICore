using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using APICore.EmailService;
using APICore.ModelService;
using System;
using APICore.DataModelService;
using Microsoft.Extensions.Options;

namespace APICore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterUserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSvc _emailSvc;

        public RegisterUserController(UserManager<ApplicationUser> userManager, IEmailSvc emailSvc)
        {
            _userManager = userManager;
            _emailSvc = emailSvc;
        }


        [HttpPost("register")]
        [AllowAnonymous]
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
                UserName = model.UserName,
                CreatedAt = DateTime.Now.ToString("F"),
                UpdatedAt = "No Update Yet"
            };

            var result = await _userManager.CreateAsync(appUser, model.Password);
            var allUsers = _userManager.Users.OrderBy(u => u.FirstName).ToList();

            if (result.Succeeded)
            {
                var userFromDb = await _userManager.FindByEmailAsync(appUser.Email);

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(userFromDb);

                string clientUrl = "http://localhost:4200/security/email-confirmation";

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
                    EmailFilePath = "EmailConfirmMessage.html",
                    Attachments = null
                };

                await _emailSvc.SendEmailAsync(emailRequest);

                //await _userManager.AddToRoleAsync(userFromDb, model.Role);

                //var claim = new Claim("JobTitle", model.JobTitle);

                //await _userManager.AddClaimAsync(userFromDb, claim);

                return Ok(new RegisterResponse() { Message = "Registration in process", IsRegistered = true });

            }

            return BadRequest(new RegisterResponse() { Message = "Registration Failed", IsRegistered = false });
        }

    }
}