using Beer2Beer.DTO;
using Beer2Beer.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beer2Beer.Services.Contracts
{
    public interface IAdminService
    {
        Task<List<UserFullDto>> FindUsersByUserName(string username);
        Task<List<UserFullDto>> FindUsersByEmail(string email);
        Task<List<UserFullDto>> FindUsersByFirstName(string firstName);
        Task<UserFullDto> Promote(string username);
        Task<UserFullDto> Demote(string username);
        Task<UserFullDto> BlockUser(string username);
        Task<UserFullDto> UnblockUser(string username);
        void IsUserNull(User user);
    }
}
