using Beer2Beer.Models;
using System.Collections.Generic;

namespace Beer2Beer.DTO
{
    public class LikesDto
    {
        public List<Like> Likes { get; set; }

        public int PostLikes { get; set; }

        public int PostDislikes { get; set; }
    }
}
