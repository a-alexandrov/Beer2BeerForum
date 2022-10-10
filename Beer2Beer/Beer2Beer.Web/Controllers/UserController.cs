using Beer2Beer.DTO;
using Beer2Beer.Services.Contracts;
using Beer2Beer.Web.Utility.Contracts;
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
        private readonly ICustomHasher customHasher;

        public UserController(IUserService userService, ICustomHasher customHasher)
        {
            this.userService = userService;
            this.customHasher = customHasher;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserRegisterDto user)
        {
            user.PasswordHash = customHasher
                .HashToString(customHasher
                .CreateHash(user.PasswordHash, customHasher
                .CreateSalt()));
            return new OkObjectResult(await this.userService.CreateUser(user));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserUpdateDto user)
        {

            // update password should probably require to reenter old password for security purposes
            if (user.PasswordHash != null)
            {
                user.PasswordHash = customHasher
                    .HashToString(customHasher
                    .CreateHash(user.PasswordHash, customHasher
                    .CreateSalt()));
            }
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
