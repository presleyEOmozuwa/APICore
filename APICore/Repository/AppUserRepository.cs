using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using APICore.DataInterfaces;
using APICore.DataModelService;
using APICore.DataService;
using APICore.GoogleService;
using APICore.ModelService;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace APICore.Repository
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _accessor;
        private readonly IGoogleJwtValidator _validator;

        public AppUserRepository(UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor, IGoogleJwtValidator validator)
        {
            _userManager = userManager;
            _accessor = accessor;
            _validator = validator;
        }

        public async Task<IList<ApplicationUser>> GetUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<ApplicationUser> GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<ApplicationUser> GetUserFromAppContext()
        {
            ClaimsPrincipal principal = _accessor.HttpContext.User;
            var claim = principal.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress");
            var userfromDb = await _userManager.FindByIdAsync(claim.Value);

            if (userfromDb != null)
            {
                return userfromDb;
            }

            return new ApplicationUser();
        }

        public async Task UpdateEmail(ApplicationUser user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async Task<ApplicationUser> UpdateFirstName(ApplicationUser user)
        {
            await _userManager.UpdateAsync(user);
            return user;
        }

        public async Task UpdateLastName(ApplicationUser user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async Task UpdateUserName(ApplicationUser user)
        {
            await _userManager.UpdateAsync(user);
        }

        public async Task DeleteUser(ApplicationUser user)
        {
            await _userManager.DeleteAsync(user);
        }

        public async Task ChangeUserPassword(ApplicationUser user, ChangePasswordModel req)
        {
            await _userManager.ChangePasswordAsync(user, req.PasswordHash, req.Password);
        }

    }
}
