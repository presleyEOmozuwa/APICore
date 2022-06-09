using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using APICore.DataInterfaces;
using APICore.DataModelService;
using APICore.ModelService;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace APICore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserRepository _appUserRepo;

        public AppUserController(IAppUserRepository appUserRepo)
        {
            _appUserRepo = appUserRepo;
        }


        [HttpGet("users")]
        //[Authorize]
        public async Task<IActionResult> GetUsers()
        {
            var model = new List<AppUserModel>();
            var usersDb = await _appUserRepo.GetUsers();
            if (usersDb != null)
            {
                foreach (var user in usersDb)
                {
                    var appModel = new AppUserModel()
                    {
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        Email = user.Email,
                        UserName = user.UserName
                    };
                    model.Add(appModel);
                }

                return Ok(model);
            }

            return NotFound(new { Status = "Request Attempt Failed" });
        }


        [HttpGet("users/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUser([FromRoute] string id)
        {
            var userDb = await _appUserRepo.GetUserById(id);
            if (userDb != null)
            {
                var model = new AppUserModel()
                {
                    FirstName = userDb.FirstName,
                    LastName = userDb.LastName,
                    Email = userDb.Email,
                    UserName = userDb.UserName
                };

                return Ok(model);
            }
            else
            {
                return BadRequest(new { Status = "Request Failed" });
            }
        }

        [HttpPost("firstname-update")]
        [Authorize]
        public async Task<IActionResult> EditFirstName([FromBody] FirstNameUpdateModel req)
        {
            var userDb = await _appUserRepo.GetUserById(req.Id);
            if (userDb != null)
            {
                userDb.FirstName = req.FirstName;
                await _appUserRepo.UpdateFirstName(userDb);
                return Ok(new { UpdatedUser = userDb, Status = "First Name Updated Successfully" });
            }

            return BadRequest(new { Status = "First Name Update Failed" });
        }

        [HttpPost("lastname-update")]
        [Authorize]
        public async Task<IActionResult> EditLastName([FromBody] LastNameUpdateModel req)
        {
            var userDb = await _appUserRepo.GetUserById(req.Id);
            if (userDb != null)
            {
                userDb.LastName = req.LastName;
                await _appUserRepo.UpdateLastName(userDb);
                return Ok(new { Status = "Last Name Updated Successfully" });
            }

            return BadRequest(new { Status = "Last Name Update Failed" });
        }

        [HttpPost("username-update")]
        [Authorize]
        public async Task<IActionResult> EditUserName([FromBody] UserNameUpdateModel req)
        {
            var userDb = await _appUserRepo.GetUserById(req.Id);
            if (userDb != null)
            {
                userDb.UserName = req.UserName;
                await _appUserRepo.UpdateLastName(userDb);
                return Ok(new { Status = "User Name Updated Successfully" });
            }

            return BadRequest(new { Status = "User Name Update Failed" });
        }

        [HttpPost("email-update")]
        [Authorize]
        public async Task<IActionResult> EditEmail([FromBody] EmailUpdateModel req)
        {
            var userDb = await _appUserRepo.GetUserById(req.Id);
            if (userDb != null)
            {
                userDb.Email = req.Email;
                await _appUserRepo.UpdateEmail(userDb);
                return Ok(new { Status = "Email Updated Successfully" });
            }

            return BadRequest(new { Status = "Email Update Failed" });
        }

        [HttpPost("delete-user")]
        [Authorize]
        public async Task<IActionResult> DeleteAppUser([FromBody] string id)
        {
            var userDb = await _appUserRepo.GetUserById(id);
            if (userDb != null)
            {
                await _appUserRepo.DeleteUser(userDb);
                return Ok(new { Status = "User Deleted Successfully" });
            }

            return BadRequest(new { Status = "User Deletion Failed" });
        }

        [HttpPost("password-change")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel req)
        {
            var userFromDb = await _appUserRepo.GetUserById(req.Id);
            if (userFromDb != null)
            {
                await _appUserRepo.ChangeUserPassword(userFromDb, req);
                return Ok(new { Status = "Password Changed Successfully" });
            }

            return BadRequest(new { Status = "Password Change Failed" });
        }

    }
}
