using Beer2Beer.DTO;
using Beer2Beer.Services.Contracts;
using Beer2Beer.Web.Utility.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public UserController(IUserService userService, ICustomHasher customHasher)
        {
            this.userService = userService;
            this.customHasher = customHasher;
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
            return new OkObjectResult(await this.userService.CreateUser(user));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UserUpdateDto user)
        {
            if (user.PasswordHash != null)
            {
                user.PasswordHash = customHasher.GetHash(user.PasswordHash);
            }

            return new OkObjectResult(await this.userService.UpdateUser(user, 0));
        }

        [HttpPut]
        [Route("avatar/{id}")]
        public async Task<IActionResult> UpdateUserAvatarAsync(IFormFile avatarImage, [FromRoute] int id)
        {
            return new OkObjectResult(await this.userService
                .UpdateUser(new UserAvatarUpdateDto { AvatarImage = avatarImage, UserId = id }));
        }

    }
}
