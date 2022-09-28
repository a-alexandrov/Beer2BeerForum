using Beer2Beer.Data.Contracts;
using System.Threading.Tasks;
using AutoMapper;
using Beer2Beer.Models;
using Beer2Beer.DTO;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Beer2Beer.Services
{
    public class UserService
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

        public async Task<UserDto> FindUserByUserName(string username)
        {

            var user = this.context.DbSet<User>()
                .FirstOrDefault(u => u.Username == username);
            await IsUserNull(user);
            var userDto = mapper.Map<UserDto>(user);
            await this.context.SaveChangesAsync();//????
            return userDto;

        }
        public async Task<UserDto> FindUserByEmail(string email)
        {

            var user = this.context.DbSet<User>()
                .FirstOrDefault(u => u.Email == email);
            await IsUserNull(user);
            var userDto = mapper.Map<UserDto>(user);
            await this.context.SaveChangesAsync();//????
            return userDto;

        }

        public async Task<List<UserDto>> FindUsersByFirstName(string firstName)
        {

            var users = await this.context.DbSet<User>()
                .Where(u => u.FirstName == firstName)
                .ToListAsync();

            var userDtos = mapper.Map<List<UserDto>>(users);
            
            return userDtos;

        }
        public async Task Promote(string username)
        {
            var user = this.context.DbSet<User>()
                .FirstOrDefault(u => u.Username == username);
            if (user.IsAdmin)
            {
                throw new ArgumentException("User is already an admin!");
            }
            else {
                user.IsAdmin = true;
                var admin = new Admin
                {
                    UserID = user.ID,
                    User = user
                };
                if (this.context.DbSet<Admin>().Contains(admin))
                {
                    var existingAdmin=this.context.DbSet<Admin>().FirstOrDefault(a=>a.ID==admin.ID);
                    existingAdmin.IsDeleted = false;
                }
                else
                {
                    this.context.DbSet<Admin>().Add(admin);
                }
            }
            await this.context.SaveChangesAsync();
        }
        public async Task Demote(string username)
        {
            var user = this.context.DbSet<User>()
                .FirstOrDefault(u => u.Username == username);
            if (!user.IsAdmin)
            {
                throw new ArgumentException("User is not an admin yet!");
            }
            else
            {
                user.IsAdmin = false;
                var admin = this.context.DbSet<Admin>()
                    .FirstOrDefault(a => a.UserID == user.ID);
                admin.IsDeleted = false;
            }
            await this.context.SaveChangesAsync();
        }

        public async Task BlockUser(string username)
        {
            var user = this.context.DbSet<User>()
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
            var user = this.context.DbSet<User>()
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

        public async Task IsUserNull (User user)
        
        {
            if (user == null) {
                throw new ArgumentNullException("User not found!");
            }
            await this.context.SaveChangesAsync();///???
        }


    }
}
