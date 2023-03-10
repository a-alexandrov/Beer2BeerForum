using AutoMapper;
using Beer2Beer.Data.Contracts;
using Beer2Beer.DTO;
using Beer2Beer.Models;
using Beer2Beer.Services.Contracts;
using Beer2Beer.Services.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Beer2Beer.Services
{
    public class UserService : IUserService
    {
        private const int MaxAvatarImageSizeBytes = 1048576;
        private const int MaxAvatarImageSizeMb = (MaxAvatarImageSizeBytes / 1024) / 1024;
        private readonly IBeer2BeerDbContext context;
        private readonly IMapper mapper;
        private readonly List<string> AllowedImageType;

        public UserService(IBeer2BeerDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            this.AllowedImageType = new List<string>()
            { 
                ".bmp", ".jpg", ".jpeg", ".png", ".gif" 
            };
        }

        public async Task<List<UserFullDto>> GetUsers()
        {
            var users = await this.context.Set<User>().Where(u => !u.IsDeleted).ToListAsync();
            return this.mapper.Map<List<UserFullDto>>(users);
        }

        public async Task<UserFullDto> GetUsersById(int id)
        {
            var user = await this.GetUserById(id);
            this.IsUserNull(user, "This user does not exist");

            return this.mapper.Map<UserFullDto>(user);
        }
        
        public async Task<UserFullDto> CreateUser(UserRegisterDto userDto)
        {
            var user = mapper.Map<User>(userDto);

            if (!this.ValidateEmail(user.Email))
            {
                throw new InvalidUserInputException(message: $"E-mail {user.Email} is invalid.");
            }

            this.context.Set<User>().Add(user);
            await this.context.SaveChangesAsync();

            return mapper.Map<UserFullDto>(user);
        }

        public async Task<UserFullDto> UpdateUser(UserUpdateDto userDto,int loginID)
        {
            
            var user = await this.GetUserById(userDto.ID);

            if (user == null || user.IsDeleted || user.ID != userDto.ID)
            {
                throw new EntityNotFoundException(message: $"User with ID:{userDto.ID} not found.");
            }

            if (userDto.CurrentUserId != userDto.ID && !user.IsAdmin)
            {
                throw new InvalidActionException("An user can only update his own info");
            }

            user.FirstName = userDto.FirstName ?? user.FirstName;
            user.LastName = userDto.LastName ?? user.LastName;
            user.PasswordHash = userDto.PasswordHash ?? user.PasswordHash;
            user.PhoneNumber = userDto.PhoneNumber ?? user.PhoneNumber;

            await this.context.SaveChangesAsync();

            return mapper.Map<UserFullDto>(user);
        }

        public async Task<UserFullDto> UpdateUser(UserAvatarUpdateDto avatarDto)
        {
            if (avatarDto.AvatarImage == null)
            {
                throw new InvalidUserInputException(message: "Invalid Input.");
            }

            var fileExtension = Path.GetExtension(avatarDto.AvatarImage.FileName);
            var isValidType = AllowedImageType.Contains(fileExtension);
            var isCorrectSize = avatarDto.AvatarImage.Length <= MaxAvatarImageSizeBytes && avatarDto.AvatarImage.Length != 0;

            if (!isValidType || !isCorrectSize)
            {
                throw new InvalidUserInputException(
                    message: $"Invalid image. Size limit: {MaxAvatarImageSizeMb}Mb.\r\n" +
                             $"Allowed formats: {string.Join(',', AllowedImageType)}");
            }

            var user = await this.GetUserById(avatarDto.UserId);

            this.IsUserNull(user, $"User with ID: {avatarDto.UserId} not found.");

            using (var target = new MemoryStream())
            {
                avatarDto.AvatarImage.CopyTo(target);
                user.AvatarImage = target.ToArray();
                user.ImageType = avatarDto.AvatarImage.FileName;
            }
            
            await this.context.SaveChangesAsync();

            return mapper.Map<UserFullDto>(user);
        }

        private void IsUserNull (User user, string message)
        {
            if (user == null) 
            {
                throw new EntityNotFoundException(message: message);
            }
        }

        private async Task<User> GetUserById(int id)
        {
            var user = await this.context.Set<User>()
                .Where(u => !u.IsDeleted)
                .Include(u => u.Posts)
                .Include(u => u.Comments)
                .FirstOrDefaultAsync(u => u.ID == id);

            return user;
        }

        private bool ValidateEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                  + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                  + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);

            return regex.IsMatch(email);
        }
    }
}
