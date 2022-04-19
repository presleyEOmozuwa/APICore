using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APICore.ModelService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stripe;

namespace APICore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public UserController(IOptions<StripeSettings> stripeSettings)
        {

        }

        //POLICY BASED AUTHORIZATION, THIS IS RECOMMENDED

        //For testing claims and policies
        [HttpGet("managerdevelopers")]
        [Authorize(Policy = "ManagerDevelopers")]
        public IActionResult AdminDesigners()
        {
            return Ok(new
            {
                role = "This user ROLE is Manager",
                claim = "User using this Api claims to be DEVELOPER"
            });
        }

        //For testing claims and policies
        [HttpGet("admindevelopers")]
        [Authorize(Policy = "AdminDevelopers")]
        public IActionResult AdminDevelopers()
        {
            return Ok(new
            {
                role = "This user ROLE is Admin",
                claim = "User using this Api claims to be DEVELOPER"
            });
        }

        //*************************************************************
        //     BELOW IS A ROLE BASED AUTHORIZATION BUT POLICY BASED IS   RECOMMENDED

        //Only admins should be able to get all admins
        //For testing roles
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult GetAllAdmins()
        {
            return Ok();
        }
        //Only admins should be able to get all managers
        //For testing roles
        [HttpGet("managers")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetAllManagers()
        {
            return Ok();
        }
        //Only admins and managers should get all non admin and users
        //For testing roles
        [HttpGet("users")]
        public IActionResult GetAllUsers()
        {
            return Ok();
        }

        [HttpGet("test")]
        [Authorize]
        public string[] GetNames()
        {
            return new string[] { "Smith", "James", "Woods" };
        }

    }
}
