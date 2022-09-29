using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services.Contracts;
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
        public async Task<UserDto> FindUserByUserName(string username)
        {

            var user = this.context.Set<User>()
                .FirstOrDefault(u => u.Username == username);
            await IsUserNull(user);
            var userDto = mapper.Map<UserDto>(user);
            await this.context.SaveChangesAsync();//????
            return userDto;

        }
        public async Task<UserDto> FindUserByEmail(string email)
        {

            var user = this.context.Set<User>()
                .FirstOrDefault(u => u.Email == email);
            await IsUserNull(user);
            var userDto = mapper.Map<UserDto>(user);
            await this.context.SaveChangesAsync();//????
            return userDto;

        }

        public async Task<List<UserDto>> FindUsersByFirstName(string firstName)
        {

            var users = await this.context.Set<User>()
            .Where(u => u.FirstName == firstName)
                .ToListAsync();

            var userDtos = mapper.Map<List<UserDto>>(users);

            return userDtos;

        }
        public async Task Promote(string username)
        {
            var user = this.context.Set<User>()
                .FirstOrDefault(u => u.Username == username);
            if (user.IsAdmin)
            {
                throw new ArgumentException("User is already an admin!");
            }
            else
            {
                user.IsAdmin = true;
                var admin = new Admin
                {
                    UserID = user.ID,
                    User = user
                };
                if (this.context.Set<Admin>().Contains(admin))
                {
                    var existingAdmin = this.context.Set<Admin>().FirstOrDefault(a => a.ID == admin.ID);
                    existingAdmin.IsDeleted = false;
                }
                else
                {
                    this.context.Set<Admin>().Add(admin);
                }
            }
            await this.context.SaveChangesAsync();
        }
        public async Task Demote(string username)
        {
            var user = this.context.Set<User>()
                .FirstOrDefault(u => u.Username == username);
            if (!user.IsAdmin)
            {
                throw new ArgumentException("User is not an admin yet!");
            }
            else
            {
                user.IsAdmin = false;
                var admin = this.context.Set<Admin>()
                    .FirstOrDefault(a => a.UserID == user.ID);
                admin.IsDeleted = false;
            }
            await this.context.SaveChangesAsync();
        }

        public async Task BlockUser(string username)
        {
            var user = this.context.Set<User>()
                .FirstOrDefault(u => u.Username == username);
            if (user.IsBlocked)
            {
                throw new ArgumentException("User is already blocked!");
            }
            else
            {
                user.IsBlocked = true;
            }
            await this.context.SaveChangesAsync();
        }

        public async Task UnblockUser(string username)
        {
            var user = this.context.Set<User>()
                .FirstOrDefault(u => u.Username == username);
            if (!user.IsBlocked)
            {
                throw new ArgumentException("User is not blocked yet!");
            }
            else
            {
                user.IsBlocked = false;
            }
            await this.context.SaveChangesAsync();
        }

        public async Task IsUserNull(User user)

        {
            if (user == null)
            {
                throw new ArgumentNullException("User not found!");
            }
            await this.context.SaveChangesAsync();///???
        }
    }
}
