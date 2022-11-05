using Beer2Beer.DTO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Beer2Beer.Services.Contracts
{
    public interface IUserService
    {
        Task<List<UserFullDto>> GetUsers();
        Task<UserFullDto> GetUsersById(int id);
        Task<UserFullDto> CreateUser(UserRegisterDto userDto);
        Task<UserFullDto> UpdateUser(UserUpdateDto userDto, int loginID);
        Task<UserFullDto> UpdateUser(UserAvatarUpdateDto avatarDto);
    }
}
