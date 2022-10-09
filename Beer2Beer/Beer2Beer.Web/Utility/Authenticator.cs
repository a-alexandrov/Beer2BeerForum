﻿using Beer2Beer.DTO;
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
        private ILoginService loginService;
        private IConfiguration config;

        public Authenticator(ILoginService loginService,IConfiguration config) 
        {
            this.loginService = loginService;
            this.config = config;
        }

        public async Task<string> GenerateJSONWebToken(UserLoginDto userLoginDto)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] 
            {
                new Claim(ClaimTypes.Email, userLoginDto.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(this.config["Jwt:Issuer"],
                this.config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            await Task.CompletedTask;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<UserLoginDto> AuthenticateUser(UserLoginDto userLoginDto)
        {
            var email = userLoginDto.Email;
            var pass = userLoginDto.Password;

            var user = await this.loginService.GetUser(email);

            //Validate the User Credentials    
            if (user.Email== email && user.PasswordHash == pass)
            {
                return userLoginDto;
            }

            await Task.CompletedTask;
            throw new ArgumentException("Invalid credentials");
        }
    }
}
