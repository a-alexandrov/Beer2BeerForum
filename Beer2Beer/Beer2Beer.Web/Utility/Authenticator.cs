using Beer2Beer.DTO;
using Beer2Beer.Services.Contracts;
using Beer2Beer.Web.Utility.Contracts;
using Beer2Beer.Web.Utility.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Utility
{
    public class Authenticator : IAuthenticator
    {
        private ILoginService loginService;
        private IConfiguration config;
        private UserRoles userRole;
        private UserStatuses userStatus;
        private const string userStatusClaimsName = "UserStatus";

        public Authenticator(ILoginService loginService, IConfiguration config)
        {
            this.loginService = loginService;
            this.config = config;
            this.userRole = UserRoles.User;
            this.userStatus = UserStatuses.Active;
        }

        public async Task<string> GenerateJSONWebToken(UserFullDto userFullDto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            if (userFullDto.IsAdmin)
            {
                this.userRole = UserRoles.Admin;
            }
            if (userFullDto.IsBlocked)
            {
                this.userStatus = UserStatuses.Blocked;
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, userFullDto.Email),
                new Claim(ClaimTypes.Role,Enum.GetName(typeof(UserRoles),this.userRole)),
                new Claim(userStatusClaimsName,Enum.GetName(typeof(UserStatuses),this.userStatus)),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(this.config["Jwt:Issuer"],
                this.config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            await Task.CompletedTask;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserFullDto> AuthenticateUser(UserLoginDto userLoginDto)
        {
            var email = userLoginDto.Email;
            var pass = userLoginDto.Password;

            var user = await this.loginService.GetUser(email);

            //Validate the User Credentials    
            if (user.Email == email && user.PasswordHash == pass)
            {
                return user;
            }

            await Task.CompletedTask;
            throw new ArgumentException("Invalid credentials");
        }
    }
}
