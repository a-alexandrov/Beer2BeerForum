using AutoMapper;
using Beer2Beer.Services.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Controllers
{
    [ApiController]
    [Route("api/admin")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService)
        {
            this.adminService = adminService;
        }

        [HttpGet]
        [Authorize(Roles = "Admin",Policy = "UserStatus")]
        [Route("byFirstName")]
        public async Task<IActionResult> GetUsersByFirstName([FromQuery] string firstName)
        {
            var users = await this.adminService.FindUsersByFirstName(firstName);

            if (!users.Any())
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }

            return this.StatusCode(StatusCodes.Status200OK, users);
        }

        [HttpGet]
        [Authorize(Roles = "Admin", Policy = "UserStatus")]
        [Route("byUsername")]
        public async Task<IActionResult> GetUsersByUsername([FromQuery] string username)
        {
            var user = await this.adminService.FindUserByUserName(username);

            if (user == null)
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }

            return this.StatusCode(StatusCodes.Status200OK, user);
        }

        [HttpGet]
        [Authorize(Roles = "Admin", Policy = "UserStatus")]
        [Route("byEmail")]
        public async Task<IActionResult> GetUsersByEmail([FromQuery] string email)
        {
            var user = await this.adminService.FindUserByEmail(email);

            if (user == null)
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }

            return this.StatusCode(StatusCodes.Status200OK, user);
        }

        [HttpPut]
        [Authorize(Roles = "Admin", Policy = "UserStatus")]
        [Route("block")]
        public async Task<IActionResult> BlockUser([FromQuery] string username)
        {
            var user = await this.adminService.BlockUser(username);

            if (user == null)
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }

            return this.StatusCode(StatusCodes.Status200OK, user);
        }

        [HttpPut]
        [Authorize(Roles = "Admin", Policy = "UserStatus")]
        [Route("unblock")]
        public async Task<IActionResult> UnblockUser([FromQuery] string username)
        {
            var user = await this.adminService.UnblockUser(username);

            if (user == null)
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }

            return this.StatusCode(StatusCodes.Status200OK, user);
        }

        [HttpPut]
        [Authorize(Roles = "Admin", Policy = "UserStatus")]
        [Route("promote")]
        public async Task<IActionResult> PromoteUser([FromQuery] string username)
        {
            var user = await this.adminService.Promote(username);

            if (user == null)
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }

            return this.StatusCode(StatusCodes.Status200OK, user);
        }

        [HttpPut]
        [Authorize(Roles = "Admin", Policy = "UserStatus")]
        [Route("demote")]
        public async Task<IActionResult> DemoteUser([FromQuery] string username)
        {
            var user = await this.adminService.Demote(username);

            if (user == null)
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }

            return this.StatusCode(StatusCodes.Status200OK, user);
        }
    }
}
