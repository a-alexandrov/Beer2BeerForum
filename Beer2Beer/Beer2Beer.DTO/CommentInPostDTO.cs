using System;

namespace Beer2Beer.DTO
{
    public class CommentInPostDTO
    {
        public UserDisplayDto User { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
