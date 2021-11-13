using DevOps06.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOps06.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {

        [HttpPost("signIn")]
        public IActionResult SignIn([FromBody]SignIn sign)
        {
            var message = $"Welcome back{sign?.Username}";
            if(sign.Username != "me")
            {
                message = "You're not authorized. check your credentials please and retry.";
            }
            else if(sign.Username == "me" && sign.Password == "Me@02")
            {
                return Ok(message);
            }
            else if(string.IsNullOrWhiteSpace(sign.Username) && string.IsNullOrWhiteSpace(sign.Password))
            {
                message = "Invalid input. please tape something in the inputs area";
            }

            return Unauthorized(message);
        }

        [HttpGet("signOut")]
        public IActionResult SignOut([FromQuery]string username)
        {
            var message = $"{username} has been signed out";
            if (string.IsNullOrWhiteSpace(username))
            {
                message = "Failed to sign out this user. there is an error.";
            }
            else if(username == "me")
            {
                return Ok(message);
            }
            else
            {
                message = "Invalid credentials. you're not allowed to sign out from this account.";
            }

            return BadRequest(message);
        }
    }
}
