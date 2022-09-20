using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
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
