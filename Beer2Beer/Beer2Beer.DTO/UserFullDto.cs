using System.Collections.Generic;
using Beer2Beer;
using Beer2Beer.Models;

namespace Beer2Beer.DTO
{
    public class UserFullDto
    {
        public bool IsBlocked { get; set; } = false;

        public bool IsAdmin { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string AvatarPath { get; set; }

        public List<Post> Posts { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
