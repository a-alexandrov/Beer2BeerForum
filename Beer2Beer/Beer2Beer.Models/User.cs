using System.Collections.Generic;

namespace Beer2Beer.Models
{
    public class User : BaseEntity
    {
        public bool IsBlocked { get; set; } = false;

        public bool IsAdmin { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public byte[] AvatarImage { get; set; }

        public string PhoneNumber { get; set; }

        public List<Post> Posts { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
