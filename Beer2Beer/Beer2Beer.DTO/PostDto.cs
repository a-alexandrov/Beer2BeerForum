
using Beer2Beer.Models;
using System.Collections.Generic;

namespace Beer2Beer.DTO
{
    public class PostDto
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int UserID { get; set; }

        public int PostLikes { get; set; }

        public int PostDislikes { get; set; }

        public int CommentsCount { get; set; }

        public List<string> Tags { get; set; }
    }
}
