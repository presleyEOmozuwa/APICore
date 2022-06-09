using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APICore.DataInterfaces;
using APICore.DataModelService;
using APICore.DataService;
using APICore.ModelService;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace APICore.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _accessor;

        public SubscriptionRepository(ApplicationDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }
        public async Task<Subscriber> CreateAsync(Subscriber subscription)
        {
            await _context.Subscribers.AddAsync(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }

        public async Task DeleteAsync(Subscriber subscription)
        {
            _context.Subscribers.Remove(subscription);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Subscriber>> GetAsync()
        {
            return await _context.Subscribers.ToListAsync();
        }

        public async Task<Subscriber> GetByCustomerIdAsync(string id)
        {
            return await _context.Subscribers.SingleOrDefaultAsync(x => x.CustomerId == id);
        }

        public async Task<Subscriber> GetByIdAsync(string id)
        {
            return await _context.Subscribers.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<SignInResponseModel> MockUp(ApplicationUser user)
        {
            var subscriber = await GetByCustomerIdAsync(user.CustomerId);

            if (subscriber != null && subscriber.Status == "active")
            {
                return new SignInResponseModel()
                {
                    ExpDate = subscriber.CurrentPeriodEnd,
                    IsAuthenticated = true,
                    IsSubscriber = true
                };
            }
            else
            {
                return new SignInResponseModel()
                {
                    ExpDate = DateTime.Now.AddDays(7),
                    IsAuthenticated = true,
                    IsSubscriber = false
                };
            }
        }

        public async Task<Subscriber> UpdateAsync(Subscriber subscription)
        {
            _context.Subscribers.UpdateRange(subscription);
            await _context.SaveChangesAsync();
            return subscription;
        }
    }
}
