using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APICore.ModelService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace APICore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SingleItemPaymentController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly StripeSettings _stripeSettings;

        public SingleItemPaymentController(UserManager<ApplicationUser> userManager, IOptions<StripeSettings> stripeSettings)
        {
            _userManager = userManager;
            _stripeSettings = stripeSettings.Value;
        }


        [HttpPost("create-checkout-session")]
        [Authorize]
        public async Task<IActionResult> CheckoutSession([FromBody] CheckoutSingleItemRequest req)
        {
            var options = new SessionCreateOptions()
            {
                SuccessUrl = req.SuccessUrl,
                CancelUrl = req.FailureUrl,
                PaymentMethodTypes = new List<string>()
                {
                    "card",
                },
                Mode = "subscription",
                LineItems = new List<SessionLineItemOptions>()
                {
                    new SessionLineItemOptions()
                    {
                        Price = req.PriceId,
                        Quantity = 1
                    }
                },
            };
            var service = new SessionService();
            //service.Create(options);
            try
            {
                var session = await service.CreateAsync(options);
                return Ok(new CheckoutSessionResponse
                {
                    SessionId = session.Id,
                    PublicKey = _stripeSettings.PublicKey
                });
            }
            catch (StripeException e)
            {
                Console.WriteLine(e.StripeError.Message);
                return BadRequest(new ErrorResponse
                {
                    ErrorMessage = new ErrorMessage
                    {
                        Message = e.StripeError.Message,
                    }
                });
            }
        }
    }
}

