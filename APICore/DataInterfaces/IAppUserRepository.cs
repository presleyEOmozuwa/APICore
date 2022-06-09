using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using APICore.DataModelService;
using APICore.ModelService;
using Microsoft.AspNetCore.Identity;

namespace APICore.DataInterfaces
{
    public interface IAppUserRepository
    {
        Task<List<ApplicationUser>> GetUsers();
        Task<ApplicationUser> GetUserById(string id);
        Task<ApplicationUser> GetUserFromAppContext();
        Task<ApplicationUser> UpdateFirstName(ApplicationUser user);
        Task UpdateLastName(ApplicationUser user);
        Task UpdateUserName(ApplicationUser user);
        Task UpdateEmail(ApplicationUser user);
        Task DeleteUser(ApplicationUser user);
        Task ChangeUserPassword(ApplicationUser user, ChangePasswordModel req);
    }
}
