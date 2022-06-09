using System;
using System.Threading.Tasks;
using APICore.DataModelService;
using APICore.ModelService;

namespace APICore.TokenService
{
    public interface IJWtokenGenerator
    {
        Task<string> GenerateToken(ApplicationUser user);
        //Task<string> TokenForExternalUser(ApplicationUser user);
    }
}
