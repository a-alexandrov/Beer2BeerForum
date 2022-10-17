using Beer2Beer.DTO;
using Beer2Beer.Services.Contracts;
using Beer2Beer.Services.CustomExceptions;
using Beer2Beer.Web.Utility.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
        private readonly IAuthenticator authenticator;

        public UserController(IUserService userService, ICustomHasher customHasher, IAuthenticator authenticator)
        {
            this.userService = userService;
            this.customHasher = customHasher;
            this.authenticator = authenticator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserRegisterDto user)
        {
            user.PasswordHash = customHasher.GetHash(user.PasswordHash);
            return new OkObjectResult(await this.userService.CreateUser(user));
        }

        [HttpPut]
        [Authorize(Roles = "Admin,User", Policy = "UserStatus")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserUpdateDto user)
        {
            var loginID = await this.authenticator.GetCurrentUserID(this.User);

            if (loginID != user.ID)
            {
                throw new InvalidActionException("An user can only update his own info");
            }

            // update password should probably require reentering old password for security purposes
            if (user.PasswordHash != null)
            {
                user.PasswordHash = customHasher.GetHash(user.PasswordHash);
            }
            return new OkObjectResult(await this.userService.UpdateUser(user));
        }

        [HttpPut]
        [Authorize(Roles = "Admin,User", Policy = "UserStatus")]
        [Route("avatar")]
        public async Task<IActionResult> UpdateUserAvatarAsync(IFormFile avatarImage, [FromForm] int userId)
        {
            return new OkObjectResult(await this.userService.UpdateUser(avatarImage, userId));
        }

    }
}
