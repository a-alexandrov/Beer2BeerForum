using Beer2Beer.DTO;
using Beer2Beer.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userServise)
        {
            this.userService = userServise;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserRegisterDto user)
        {
            return new OkObjectResult(await this.userService.CreateUser(user));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserUpdateDto user)
        {
            return new OkObjectResult(await this.userService.UpdateUser(user));
        }

        [HttpPut]
        [Route("avatar")]
        public async Task<IActionResult> UpdateUserAvatarAsync(IFormFile avatarImage, [FromForm] int userId)
        {
            return new OkObjectResult(await this.userService.UpdateUser(avatarImage, userId));
        }

    }
}
