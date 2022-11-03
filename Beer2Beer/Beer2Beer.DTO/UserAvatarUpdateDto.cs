using Microsoft.AspNetCore.Http;

namespace Beer2Beer.DTO
{
    public class UserAvatarUpdateDto
    {
        public IFormFile AvatarImage { get; set; }
        public int UserId { get; set; }
    }
}
