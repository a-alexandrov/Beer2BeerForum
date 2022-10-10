using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services.Contracts;
using Beer2Beer.Services.CustomExceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beer2Beer.Services
{
    public class LoginService:ILoginService
    {
        private readonly IBeer2BeerDbContext context;
        private readonly IMapper mapper;

        public LoginService(IBeer2BeerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<UserFullDto> GetUser(string email)
        {
            var user = await this.context.Set<User>().FirstOrDefaultAsync(u => u.Email == email);

            IsUserNull(user);

            var userDto = mapper.Map<UserFullDto>(user);
            return userDto;
        }

        public void IsUserNull(User user)
        {
            if (user == null)
            {
                throw new EntityNotFoundException("User not found!");
            }
        }
    }
}
