using Beer2Beer.DTO;
using Beer2Beer.Web.Utility.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : Controller
    {
        private IAuthenticator authenticator;

        public LoginController(IAuthenticator authenticator) 
        {
            this.authenticator = authenticator;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto) 
        {
            IActionResult response = Unauthorized();
            var user = await this.authenticator.AuthenticateUser(userLoginDto);

            if (user != null)
            {
                var tokenString = await this.authenticator.GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }

            await Task.CompletedTask;
            return response;
        }
    }
}
