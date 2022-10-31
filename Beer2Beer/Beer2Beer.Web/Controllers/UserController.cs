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
    [Authorize(Policy = "UserStatus")]
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            return new OkObjectResult(await this.userService.GetUsers());
        }

        [HttpGet]
        [Route ("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return new OkObjectResult(await this.userService.GetUsersById(id));
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserRegisterDto user)
        {
            user.Password = customHasher.GetHash(user.Password);
            await this.userService.CreateUser(user);
            return new OkObjectResult($"User {user.Username} created!");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserUpdateDto user)
        {
            var loginID = await this.authenticator.GetCurrentUserID(this.User);

            // update password should probably require reentering old password for security purposes
            if (user.PasswordHash != null)
            {
                user.PasswordHash = customHasher.GetHash(user.PasswordHash);
            }
            return new OkObjectResult(await this.userService.UpdateUser(user,loginID));
        }

        [HttpPut]
        [Route("avatar")]
        public async Task<IActionResult> UpdateUserAvatarAsync(IFormFile avatarImage, [FromForm] int userId)
        {
            return new OkObjectResult(await this.userService.UpdateUser(avatarImage, userId));
        }

    }
}
