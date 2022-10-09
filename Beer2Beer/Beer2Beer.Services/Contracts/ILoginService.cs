using Beer2Beer.DTO;
using Beer2Beer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beer2Beer.Services.Contracts
{
    public interface ILoginService
    {
        Task<UserFullDto> GetUser(string email);
        void IsUserNull(User user);
    }
}
