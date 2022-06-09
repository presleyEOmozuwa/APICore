using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using APICore.ModelService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Stripe;
using Twilio.Clients;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace APICore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly StripeSettings _stripeSettings;
        private readonly IHttpContextAccessor _accessor;

        public UserController(IOptions<StripeSettings> stripeSettings, IHttpContextAccessor accessor)
        {
            _stripeSettings = stripeSettings.Value;
            _accessor = accessor;
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

        [HttpGet("values")]
        public string[] GetAllVal()
        {
            string path = _accessor.HttpContext.Request.Path.Value;
            return new string[] { "Apples", "Books", path };
        }

        [HttpGet("test")]
        public string GetNames()
        {
            var host = Dns.GetHostEntry("www.facebook.com");
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");

            //return new string[] { "Presley", "Alexis", "Woods", ipAddress };
        }

        [HttpGet("address")]
        public string GetIp()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

    }
}
