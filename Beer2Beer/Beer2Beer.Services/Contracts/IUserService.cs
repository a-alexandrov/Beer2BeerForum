using Beer2Beer.DTO;
using System.Threading.Tasks;

namespace Beer2Beer.Services.Contracts
{
    public interface IUserService
    {
        Task<UserFullDto> CreateUser(UserRegisterDto userDto);
        Task<UserFullDto> UpdateUser(UserUpdateDto userDto);
    }
}
