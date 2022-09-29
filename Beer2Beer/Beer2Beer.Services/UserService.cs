using Beer2Beer.Data.Contracts;
using System.Threading.Tasks;
using AutoMapper;
using Beer2Beer.Models;
using Beer2Beer.DTO;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Beer2Beer.Services.Contracts;

namespace Beer2Beer.Services
{
    public class UserService : IUserService
    {
        private readonly IBeer2BeerDbContext context;
        private readonly IMapper mapper;

        public UserService(IBeer2BeerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task RegisterUser(RegisterUserDto userDto)
        {
            var user = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                PasswordHash = userDto.Password
            };

            this.context.DbSet<User>().Add(user);

            await this.context.SaveChangesAsync();
        }

        public async Task ChangeFirstName(string firstName, LoginUserDto userDto)
        {

            this.context.DbSet<User>()
                .FirstOrDefault(u => u.Username == userDto.Username)
                .FirstName = firstName;

            await this.context.SaveChangesAsync();
        }
        public async Task ChangeLastName(string lastName, LoginUserDto userDto)
        {

            this.context.DbSet<User>()
                .FirstOrDefault(u => u.Username == userDto.Username)
                .LastName = lastName;

            await this.context.SaveChangesAsync();
        }

        public async Task ChangePassword(string newPassword, LoginUserDto userDto)
        {

            this.context.DbSet<User>()
                .FirstOrDefault(u => u.Username == userDto.Username)
                .PasswordHash = newPassword;

            await this.context.SaveChangesAsync();
        }

        public async Task ChangeAvatarPath(string newAvatarPath, LoginUserDto userDto)
        {

            this.context.DbSet<User>()
                .FirstOrDefault(u => u.Username == userDto.Username)
                .AvatarPath = newAvatarPath;

            await this.context.SaveChangesAsync();
        }


        public async Task Login(string username, string password)
        {
            // ToDo:implement

            var user = this.context.DbSet<User>()
                .FirstOrDefault(u => u.Username == username);

            if (user == null)
            {
                throw new ArgumentException($"User with username {username} cannot be found!");
            }
            if (user.PasswordHash != password)
            {
                throw new ArgumentException($"Wrong password!");
            }

            await this.context.SaveChangesAsync();///?????
            throw new NotImplementedException();
        }

        public async Task Logout()
        {
            //ToDo:implement
            await this.context.SaveChangesAsync();///?????
            throw new NotImplementedException();
        }

        public async Task IsUserNull (User user)
        
        {
            if (user == null) {
                throw new ArgumentNullException("User not found!");
            }
            await this.context.SaveChangesAsync();///???
        }


    }
}
