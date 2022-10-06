using Beer2Beer.DTO;
using Beer2Beer.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Utility
{
    public class Authenticator:IAuthenticator
    {
        private IAdminService adminService;
        private IConfiguration config;

        public Authenticator(IAdminService adminService,IConfiguration config) 
        {
            this.adminService = adminService;
            this.config = config;
        }

        public async Task<string> GenerateJSONWebToken(UserLoginDto userLoginDto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] 
            {
                new Claim(JwtRegisteredClaimNames.Sub, userLoginDto.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(this.config["Jwt:Issuer"],
                this.config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            await Task.CompletedTask;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserLoginDto> AuthenticateUser(UserLoginDto userLoginDto)
        {
            var name = userLoginDto.Username;
            var pass = userLoginDto.Password;

            var user = await this.adminService.FindUserByUserName(name);

            //Validate the User Credentials    
            if (user.Username == name && user.PasswordHash == pass)
            {
                return userLoginDto;
            }

            await Task.CompletedTask;
            throw new ArgumentException("User not found");
        }
    }
}
