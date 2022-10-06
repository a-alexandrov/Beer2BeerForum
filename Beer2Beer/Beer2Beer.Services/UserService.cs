using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services.Contracts;
using Beer2Beer.Services.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Beer2Beer.Services
{
    public class UserService : IUserService
    {
        private const int MaxAvatarImageSize = 1048576;
        private readonly IBeer2BeerDbContext context;
        private readonly IMapper mapper;
        private readonly List<string> AllowedImageType;

        public UserService(IBeer2BeerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.AllowedImageType = new List<string>()
            { 
                ".bmp", ".jpg", ".jpeg", ".png" 
            };
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
                throw new InvalidUserInputException(message: $"User with ID:{userDto.ID} not found.");
            }

            user.FirstName = userDto.FirstName ?? user.FirstName;
            user.LastName = userDto.LastName ?? userDto.LastName;
            user.PasswordHash = userDto.PasswordHash ?? userDto.PasswordHash;

            await this.context.SaveChangesAsync();

            return mapper.Map<UserFullDto>(user);
        }

        public async Task<UserFullDto> UpdateUser(IFormFile avatarImage, int userId)
        {
            if (avatarImage == null)
            {
                throw new InvalidUserInputException(message: "Invalid Input.");
            }

            var isValidType = AllowedImageType.Contains(avatarImage.ContentType);
            var isCorrectSize = avatarImage.Length <= MaxAvatarImageSize && avatarImage.Length != 0;

            //Should we keep a name in db for the uploaded file?
            //var fileName = Guid.NewGuid() + "_" + userId + avatarImage.ContentType;

            var user = await this.GetUserById(userId);

            if (!(isValidType || isCorrectSize))
            {
                throw new InvalidUserInputException(message: "Invalid image.");
            }
            else if (user == null)
            {
                throw new InvalidUserInputException(message: $"User with ID: {userId} not found.");
            }

            using (var target = new MemoryStream())
            {
                avatarImage.CopyTo(target);
                user.AvatarImage = target.ToArray();
            }
            
            await this.context.SaveChangesAsync();

            return mapper.Map<UserFullDto>(user);
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
