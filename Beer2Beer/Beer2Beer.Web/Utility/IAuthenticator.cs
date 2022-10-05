using Beer2Beer.DTO;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Utility
{
    public interface IAuthenticator
    {
        Task<string> GenerateJSONWebToken(UserLoginDto userLoginDto);
        Task<UserLoginDto> AuthenticateUser(UserLoginDto userLoginDto);
    }
}
