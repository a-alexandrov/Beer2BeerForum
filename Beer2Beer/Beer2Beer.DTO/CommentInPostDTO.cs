using Beer2Beer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beer2Beer.DTO
{
    public class CommentInPostDTO
    {
        public UserDisplayDto User { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
