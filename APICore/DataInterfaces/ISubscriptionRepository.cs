using System.Collections.Generic;
using System.Threading.Tasks;
using APICore.DataModelService;
using APICore.ModelService;

namespace APICore.DataInterfaces
{
    public interface ISubscriptionRepository
    {
        Task<List<Subscriber>> GetAsync();
        Task<Subscriber> GetByIdAsync(string id);
        Task<Subscriber> GetByCustomerIdAsync(string id);
        Task<Subscriber> CreateAsync(Subscriber subscription);
        Task<Subscriber> UpdateAsync(Subscriber subscription);
        Task DeleteAsync(Subscriber subscription);
        Task<SignInResponseModel> MockUp(ApplicationUser user);
    }
}
