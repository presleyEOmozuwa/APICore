using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.DataModelService;
using APICore.EmailService;
using APICore.ModelService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSvc _emailSvc;

        public SecurityController(UserManager<ApplicationUser> userManager, IEmailSvc emailSvc)
        {
            _userManager = userManager;
            _emailSvc = emailSvc;
        }


        [HttpPost("forgotpassword")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel req)
        {
            var user = await _userManager.FindByEmailAsync(req.Email);

            if (user == null)
            {
                return BadRequest();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            string clientUrl = "http://localhost:4200/security/reset-password";
            Dictionary<string, string> keyValues = new Dictionary<string, string>()
            {
                {"token", token },
                {"id",  user.Id}
            };

            string callBackUrl = QueryHelpers.AddQueryString(clientUrl, keyValues);
            var emailRequest = new EmailRequest()
            {
                CallBackUrl = callBackUrl,
                ToEmail = user.Email,
                ToName = $"{user.FirstName} {user.LastName}",
                Subject = "Password Reset Request Mail",
                EmailFilePath = "PasswordResetConfirmation.html",
                Attachments = null
            };

            await _emailSvc.SendEmailAsync(emailRequest);
            return Ok(new SecurityResponse() { Message = "Password Request Email Sent", Status = true });
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


        [HttpPost("resetpassword")]
        public async Task<IActionResult> ResetPassword([FromBody] PasswordResetModel req)
        {
            var userfromDb = await _userManager.FindByIdAsync(req.Id);

            if (userfromDb == null)
            {
                return BadRequest();
            }


            var result = await _userManager.ResetPasswordAsync(userfromDb, req.Token, req.Password);

            if (result.Succeeded)
            {
                return Ok(new SecurityResponse() { Message = "Password Reset was Successful", Status = true });
            }

            return Ok(new SecurityResponse() { Message = "Password Reset Failed", Status = false });

        }
    }
}
