using AutoMapper;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Controllers
{
    [ApiController]
    [Route("api/admin")]
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


        [HttpGet("{users}")]
        public IActionResult Get([FromQuery] string querytype,string queryparam)
        {
            if (querytype == "username")
            {
                var user = this.adminService.FindUserByUserName(queryparam);
                if (user == null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound);
                }
                return this.StatusCode(StatusCodes.Status200OK, user);

            }

            else if (querytype == "email")
            {
                var user = this.adminService.FindUserByEmail(queryparam);
                if (user == null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound);
                }
                return this.StatusCode(StatusCodes.Status200OK, user);
            }
            

            else if (querytype =="firstname")
            {
                //ToDo: fix object cycle bug 
                var users = this.adminService.FindUsersByFirstName(queryparam);
                if (users ==null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound);
                }
                return this.StatusCode(StatusCodes.Status200OK, users);

            }
            else
            {
                return this.StatusCode(StatusCodes.Status400BadRequest);
            }


        }

        [HttpPut("{users}")]
        public IActionResult Put([FromQuery] string queryType, string queryParam)
        {

            if (queryType == "block")
            {
                var user = this.adminService.BlockUser(queryParam);
                if (user == null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound);
                }
                return this.StatusCode(StatusCodes.Status200OK);
            }
            else if (queryType == "unblock")
            {
                var user = this.adminService.UnblockUser(queryParam);
                if (user == null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound);
                }
                return this.StatusCode(StatusCodes.Status200OK);
            }

            else if (queryType == "promote") {
                var user = this.adminService.Promote(queryParam);
                if (user == null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound);
                }
                return this.StatusCode(StatusCodes.Status200OK);
            }

            else if (queryType == "demote")
            {
                var user = this.adminService.Demote(queryParam);
                if (user == null)
                {
                    return this.StatusCode(StatusCodes.Status404NotFound);
                }
                return this.StatusCode(StatusCodes.Status200OK);
            }

            return this.StatusCode(StatusCodes.Status400BadRequest);
            

        }

    }
}
