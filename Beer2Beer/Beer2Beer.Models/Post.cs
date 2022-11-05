using System.Collections.Generic;

namespace Beer2Beer.Models
{
    public class Post: BaseEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int UserID { get; set; }

        public User User { get; set; }

        public int PostLikes { get; set; }

        public int PostDislikes { get; set; }

        public List<Like> Likes { get; set; }

        public int CommentsCount { get; set; }

        public List<Comment> Comments { get; set; }

        public List<TagPost> TagPosts { get; set; }
    }
}
