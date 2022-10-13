using Beer2Beer.DTO;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Beer2Beer.Web.Utility.Contracts
{
    public interface IAuthenticator
    {
        Task<string> GenerateJSONWebToken(UserFullDto userLoginDto);
        Task<UserFullDto> AuthenticateUser(UserLoginDto userLoginDto);
        Task<int> GetCurrentUserID(ClaimsPrincipal claimsPrincipal);
    }
}
