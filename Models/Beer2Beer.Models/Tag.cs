using System.Collections.Generic;

namespace Beer2Beer
{
    public class Tag: BaseEntity
    {
        public string Name { get; set; }
        public List<TagPost> TagPosts { get; set; }
    }
}
