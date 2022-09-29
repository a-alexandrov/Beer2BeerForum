using Beer2Beer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Beer2Beer.Web.Models;
using System;

namespace Beer2Beer.Web.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IAdminService adminService;
        

        public UserController(IAdminService adminService) {
            this.adminService = adminService;
        }

        [HttpGet("{username}")]
        public IActionResult GetUserByUsername([FromQuery] string username)
        {

            var user = this.adminService.FindUserByUserName(username);
            if (user == null) {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }    
            return this.StatusCode(StatusCodes.Status200OK, user);
        }

        [HttpGet("{email}")]
        public IActionResult GetUserByEmail([FromQuery] string email)
        {

            var user = this.adminService.FindUserByEmail(email);
            if (user == null)
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }
            return this.StatusCode(StatusCodes.Status200OK, user);
        }
        [HttpGet("{firstName}")]
        public IActionResult GetUsersByFirstName([FromQuery] string firstName) { 
        
            var users = this.adminService.FindUsersByFirstName(firstName);
            if (users == null) {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }
            return this. StatusCode(StatusCodes.Status200OK, users);
        }

        [HttpPut("")]

        public IActionResult BlockUser([FromQuery] string username) {
            var user = this.adminService.BlockUser(username);
            if (user == null)
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }
            return this.StatusCode(StatusCodes.Status200OK, user);


        }
        [HttpPut("")]
        public IActionResult UnblockUser([FromQuery] string username)
        {
            var user = this.adminService.UnblockUser(username);
            if (user == null)
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }
            return this.StatusCode(StatusCodes.Status200OK, user);


        }



    }
}
