﻿using Beer2Beer.DTO;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Utility
{
    public interface IAuthenticator
    {
        Task<string> GenerateJSONWebToken(UserFullDto userLoginDto);
        Task<UserFullDto> AuthenticateUser(UserLoginDto userLoginDto);
    }
}
