using System;
using System.IO;
using System.Threading.Tasks;
using APICore.DataInterfaces;
using APICore.DataModelService;
using APICore.ModelService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;


namespace APICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeWebhookController : ControllerBase
    {
        private readonly StripeSettings _stripeSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISubscriptionRepository _subscriberRepository;
        public StripeWebhookController(IOptions<StripeSettings> stripeSettings, UserManager<ApplicationUser> userManager, ISubscriptionRepository subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
            _stripeSettings = stripeSettings.Value;
            _userManager = userManager;
        }


        [HttpPost("webhook")]
        public async Task<IActionResult> WebHook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(
                    json,
                    Request.Headers["Stripe-Signature"],
                    _stripeSettings.WHSecret
                );


                // Handle the event
                if (stripeEvent.Type == Events.CustomerSubscriptionCreated)
                {
                    var subscription = stripeEvent.Data.Object as Subscription;
                    //Do stuff
                    await AddSubscriptionToDb(subscription);
                }
                else if (stripeEvent.Type == Events.CustomerSubscriptionUpdated)
                {
                    var session = stripeEvent.Data.Object as Subscription;

                    // Update Subsription
                    await UpdateSubscription(session);
                }
                else if (stripeEvent.Type == Events.CustomerCreated)
                {
                    var customer = stripeEvent.Data.Object as Customer;
                    //Do Stuff
                    await AddCustomerIdToUser(customer);
                }
                // ... handle other event types
                else
                {
                    // Unexpected event type
                    Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                }
                return Ok();
            }
            catch (StripeException e)
            {
                Console.WriteLine(e.StripeError.Message);
                return BadRequest();
            }
        }


        private async Task UpdateSubscription(Subscription subscription)
        {
            try
            {
                var subscriptionFromDb = await _subscriberRepository.GetByIdAsync(subscription.Id);
                if (subscriptionFromDb != null)
                {
                    subscriptionFromDb.Status = subscription.Status;
                    subscriptionFromDb.CurrentPeriodEnd = subscription.CurrentPeriodEnd;
                    await _subscriberRepository.UpdateAsync(subscriptionFromDb);
                    Console.WriteLine("Subscription Updated");
                }

            }
            catch (StripeException ex)
            {
                Console.WriteLine(ex.StripeError.Message);

                Console.WriteLine("Unable to update subscription");

            }

        }


        private async Task AddCustomerIdToUser(Customer customer)
        {
            try
            {
                var userFromDb = await _userManager.FindByEmailAsync(customer.Email);

                if (userFromDb != null)
                {
                    userFromDb.CustomerId = customer.Id;
                    await _userManager.UpdateAsync(userFromDb);
                    Console.WriteLine("Customer Id added to user ");
                }

            }
            catch (StripeException ex)
            {
                Console.WriteLine("Unable to add customer id to user");
                Console.WriteLine(ex);
            }
        }


        private async Task AddSubscriptionToDb(Subscription subscription)
        {
            try
            {
                var subscriber = new Subscriber()
                {
                    Id = subscription.Id,
                    CustomerId = subscription.CustomerId,
                    Status = "active",
                    CurrentPeriodEnd = subscription.CurrentPeriodEnd
                };
                await _subscriberRepository.CreateAsync(subscriber);

                //You can send the new subscriber an email welcoming the new subscriber
            }
            catch (StripeException ex)
            {
                Console.WriteLine("Unable to add new subscriber to Database");
                Console.WriteLine(ex.StripeError.Message);
            }
        }
    }

}