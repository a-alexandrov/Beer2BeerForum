using System.Collections.Generic;

namespace Beer2Beer
{
    public class Post:BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public int PostLikes { get; set; }


        public List<Comment> Comments { get; set; }
        public List<TagPost> TagPosts { get; set; }

    }
}
