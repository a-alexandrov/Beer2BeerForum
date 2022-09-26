using System.Collections.Generic;

namespace Beer2Beer.Models
{
    public class User: BaseEntity
    {
        public bool IsBlocked { get; set; } = false;

        public string FirstName { get; set; }

        public string LastName{ get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public string AvatarPath { get; set; }

        public List<Post> Posts { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
