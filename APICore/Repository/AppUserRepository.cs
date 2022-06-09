using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
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
using Microsoft.Extensions.Options;

namespace APICore.Repository
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _accessor;
        private readonly HttpClient _httpClient;
        private readonly UserApiOptions _userOptions;

        public AppUserRepository(UserManager<ApplicationUser> userManager, IHttpContextAccessor accessor, HttpClient httpClient, IOptions<UserApiOptions> userOptions)
        {
            _userManager = userManager;
            _accessor = accessor;
            _httpClient = httpClient;
            _userOptions = userOptions.Value;
        }

        public async Task<List<ApplicationUser>> GetUsers()
        {
            var userResponse = await _httpClient.GetAsync(_userOptions.Endpoint);
            if (userResponse.StatusCode == HttpStatusCode.NotFound)
            {
                return new List<ApplicationUser>();
            }
            else
            {
                var responseContent = userResponse.Content;
                var allUsers = await responseContent.ReadFromJsonAsync<List<ApplicationUser>>();
                return allUsers;
            }
        }


        //public async Task<List<ApplicationUser>> GetUsers()
        //{
        //    var users = _userManager.Users;
        //    return await Task.FromResult(users.ToList());
        //}


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
