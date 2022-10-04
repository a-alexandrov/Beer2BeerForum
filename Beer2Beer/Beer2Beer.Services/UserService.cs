using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<UserFullDto> CreateUser(UserRegisterDto userDto)
        {
            var user = mapper.Map<User>(userDto);

            this.context.Set<User>().Add(user);
            await this.context.SaveChangesAsync();

            return mapper.Map<UserFullDto>(user);
        }

        public async Task<UserFullDto> UpdateUser(UserUpdateDto userDto)
        {
            var user = await this.GetUserById(userDto.ID);

            if (user == null)
            {
                throw new NullReferenceException(message: $"User with ID:{userDto.ID} not found.");
            }

            user.FirstName = userDto.FirstName ?? user.FirstName;
            user.LastName = userDto.LastName ?? userDto.LastName;
            user.PasswordHash = userDto.PasswordHash ?? userDto.PasswordHash;

            await this.context.SaveChangesAsync();

            return mapper.Map<UserFullDto>(user);
        }

        //Might place ChangeAvatarPath in UpdateUser.
        //Implement UploadPicture method.
        public async Task ChangeAvatarPath(string newAvatarPath, UserLoginDto userDto)
        {

            this.context.Set<User>()
                .FirstOrDefault(u => u.Username == userDto.Username)
                .AvatarPath = newAvatarPath;

            await this.context.SaveChangesAsync();
        }

        public async Task Login(string username, string password)
        {
            // ToDo:implement

            var user = this.context.Set<User>()
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

        private async Task<User> GetUserById(int id)
        {
            var user = await this.context.Set<User>()
                .FirstOrDefaultAsync(u => u.ID == id);

            return user;
        }
    }
}
