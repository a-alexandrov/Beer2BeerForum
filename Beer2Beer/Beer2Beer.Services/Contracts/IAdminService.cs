using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beer2Beer.Services.Contracts
{
    public interface IAdminService
    {
        Task<UserFullDto> FindUserByUserName(string username);
        Task<UserFullDto> FindUserByEmail(string email);
        Task<List<UserFullDto>> FindUsersByFirstName(string firstName);
        Task Promote(string username);
        Task Demote(string username);
        Task BlockUser(string username);
        Task UnblockUser(string username);
        Task IsUserNull(User user);

    }
}
