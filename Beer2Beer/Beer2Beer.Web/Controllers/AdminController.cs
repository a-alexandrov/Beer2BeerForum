using AutoMapper;
using Beer2Beer.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Beer2Beer.Web.Controllers
{
    public class AdminController : ControllerBase
    {

        private readonly IAdminService adminService;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public AdminController(IUserService userServise, IAdminService adminService, IMapper mapper)
        {
            this.adminService = adminService;
            this.mapper = mapper;
            this.userService = userServise;
        }


        [HttpGet("{username}")]
        public IActionResult GetUserByUsername([FromQuery] string username)
        {

            var user = this.adminService.FindUserByUserName(username);

            if (user == null)
            {
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
        public IActionResult GetUsersByFirstName([FromQuery] string firstName)
        {

            var users = this.adminService.FindUsersByFirstName(firstName);

            if (users == null)
            {
                return this.StatusCode(StatusCodes.Status404NotFound);
            }

            return this.StatusCode(StatusCodes.Status200OK, users);
        }

        //[HttpPut("")]
        //public IActionResult BlockUser([FromQuery] string username) {
        //    var user = this.adminService.BlockUser(username);
        //    if (user == null)
        //    {
        //        return this.StatusCode(StatusCodes.Status404NotFound);
        //    }
        //    return this.StatusCode(StatusCodes.Status200OK, user);

        //}
        //[HttpPut("")]
        //public IActionResult UnblockUser([FromQuery] string username)
        //{
        //    var user = this.adminService.UnblockUser(username);
        //    if (user == null)
        //    {
        //        return this.StatusCode(StatusCodes.Status404NotFound);
        //    }
        //    return this.StatusCode(StatusCodes.Status200OK, user);
        //}

    }
}
