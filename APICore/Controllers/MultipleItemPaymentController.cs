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
    public class MultipleItemPaymentController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly StripeSettings _stripeSettings;

        public MultipleItemPaymentController(UserManager<ApplicationUser> userManager, IOptions<StripeSettings> stripeSettings)
        {
            _userManager = userManager;
            _stripeSettings = stripeSettings.Value;
        }


        [HttpPost("create-checkout-session")]
        [Authorize]
        public async Task<IActionResult> CheckoutSession([FromBody] CheckoutItemListRequest req)
        {
            var lineItemsOptions = new List<SessionLineItemOptions>();

            foreach (var priceId in req.PriceIds)
            {
                var lineOption = new SessionLineItemOptions()
                {
                    Price = priceId,
                    Quantity = 1
                };

                lineItemsOptions.Add(lineOption);
            }

            var options = new SessionCreateOptions()
            {
                SuccessUrl = req.SuccessUrl,
                CancelUrl = req.FailureUrl,
                PaymentMethodTypes = new List<string>()
                {
                    "card",
                },
                Mode = "subscription",
                LineItems = lineItemsOptions
            };

            var service = new SessionService();
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
