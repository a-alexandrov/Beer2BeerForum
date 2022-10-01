using Beer2Beer.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Beer2Beer.Web.Models;
using System;
using AutoMapper;
using Beer2Beer.DTO;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IAdminService adminService;
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UserController(IUserService userServise, IAdminService adminService, IMapper mapper)
        {
            this.adminService = adminService;
            this.mapper = mapper;
            this.userService = userServise;
        }

        /// <summary>
        /// Registers a User in the DataBase.
        /// </summary>
        /// <remarks>
        /// Registers a User in the DataBase.
        /// </remarks>
        /// 
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserRegisterDto user)
        {
            if(!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            try
            {
                await this.userService.CreateUser(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
