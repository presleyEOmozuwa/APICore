using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using APICore.ModelService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.BillingPortal;

namespace APICore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortalController : ControllerBase
    {
        private readonly StripeSettings _stripeSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PortalController(IOptions<StripeSettings> stripeSettings, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _stripeSettings = stripeSettings.Value;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpPost("customer-portal")]
        [Authorize]
        public async Task<IActionResult> CustomerPortal([FromBody] CustomerPortalRequest req)
        {
            try
            {
                ClaimsPrincipal principal = _httpContextAccessor.HttpContext.User;
                var claim = principal.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname");
                var userFromDb = await _userManager.FindByNameAsync(claim.Value);

                if (userFromDb == null)
                {
                    return BadRequest();
                }


                var options = new SessionCreateOptions()
                {
                    Customer = userFromDb.CustomerId,
                    ReturnUrl = req.ReturnUrl
                };

                var service = new SessionService();
                var session = await service.CreateAsync(options);

                return Ok(new { url = session.Url });
            }
            catch (StripeException ex)
            {
                var errorMessage = new ErrorMessage()
                {
                    Message = ex.StripeError.Message
                };
                var errorResponse = new ErrorResponse()
                {
                    ErrorMessage = errorMessage
                };
                Console.WriteLine(ex.StripeError.Message);

                return BadRequest(errorResponse);
            }

        }

    }
}
