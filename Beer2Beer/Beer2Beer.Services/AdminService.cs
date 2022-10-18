using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services.Contracts;
using Beer2Beer.Services.CustomExceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beer2Beer.Services
{
    public class AdminService : IAdminService
    {
        private readonly IBeer2BeerDbContext context;
        private readonly IMapper mapper;

        public AdminService(IBeer2BeerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<UserFullDto> FindUserByUserName(string username)
        {
            var user = await this.context.Set<User>()
                .Where(u=>!u.IsDeleted)
                .FirstOrDefaultAsync(u => u.Username == username);

            IsUserNull(user);

            var userDto = mapper.Map<UserFullDto>(user);

            return userDto;
        }

        public async Task<UserFullDto> FindUserByEmail(string email)
        {
            var user = await this.context.Set<User>()
                .Where(u => !u.IsDeleted)
                .FirstOrDefaultAsync(u => u.Email == email);

            IsUserNull(user);

            var userDto = mapper.Map<UserFullDto>(user);
            return userDto;
        }

        public async Task<List<UserFullDto>> FindUsersByFirstName(string firstName)
        {
            var users = await this.context.Set<User>()
            .Where(u => u.FirstName.Contains(firstName))
            .Where(u => !u.IsDeleted)
            .ToListAsync();

            if (!users.Any())
            {
                throw new EntityNotFoundException($"There aren't any users with firstname {firstName}");
            }

            var userDtos = mapper.Map<List<UserFullDto>>(users);

            return userDtos;
        }

        public async Task<UserFullDto> Promote(string username)
        {
            var user = await this.context.Set<User>()
                .Where(u => !u.IsDeleted)
                .FirstOrDefaultAsync(u => u.Username == username);

            IsUserNull(user);

            if (user.IsAdmin)
            {
                throw new InvalidActionException("User is already an admin!");
            }
            else
            {
                user.IsAdmin = true;
            }

            await this.context.SaveChangesAsync();
            var result = mapper.Map<UserFullDto>(user);

            return result;
        }

        public async Task<UserFullDto> Demote(string username)
        {
            var user = await this.context.Set<User>()
                .Where(u => !u.IsDeleted)
                .FirstOrDefaultAsync(u => u.Username == username);

            IsUserNull(user);

            if (!user.IsAdmin)
            {
                throw new InvalidActionException("User is not an admin yet!");
            }
            else
            {
                user.IsAdmin = false;
            }

            await this.context.SaveChangesAsync();
            var result = mapper.Map<UserFullDto>(user);

            return result;
        }

        public async Task<UserFullDto> BlockUser(string username)
        {
            var user = await this.context.Set<User>()
                .Where(u => !u.IsDeleted)
                .FirstOrDefaultAsync(u => u.Username == username);
            IsUserNull(user);

            if (user.IsBlocked)
            {
                throw new InvalidActionException("User is already blocked!");
            }
            else
            {
                user.IsBlocked = true;
            }

            await this.context.SaveChangesAsync();
            var result = mapper.Map<UserFullDto>(user);

            return result;
        }

        public async Task<UserFullDto> UnblockUser(string username)
        {
            var user = await this.context.Set<User>()
                .Where(u => !u.IsDeleted)
                .FirstOrDefaultAsync(u => u.Username == username);
            IsUserNull(user);

            if (!user.IsBlocked)
            {
                throw new InvalidActionException("User is not blocked yet!");
            }
            else
            {
                user.IsBlocked = false;
            }

            await this.context.SaveChangesAsync();
            var result = mapper.Map<UserFullDto>(user);

            return result;
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
