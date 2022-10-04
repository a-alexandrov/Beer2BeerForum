﻿using AutoMapper;
using Beer2Beer.DTO;
using Beer2Beer.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;

        public UserController(IUserService userServise, IMapper mapper)
        {
            this.mapper = mapper;
            this.userService = userServise;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserRegisterDto user)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var registeredUser = new UserFullDto();

            try
            {
                registeredUser = await this.userService.CreateUser(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, user);
            }

            return StatusCode(StatusCodes.Status200OK, registeredUser);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserUpdateDto user)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            var updatedUser = new UserFullDto();

            try
            {
                updatedUser = await this.userService.UpdateUser(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            return StatusCode(StatusCodes.Status200OK, updatedUser);
        }
    }
}
