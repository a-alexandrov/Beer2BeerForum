using System;
using System.Collections.Generic;
using System.Text;

namespace Beer2Beer.DTO
{
    public class PostQueryParameters
    {
        public int? UserId { get; set; }
        public string Keyword { get; set; }
        public int? minLikes { get; set; }
        public int? maxLikes { get; set; }
        public int? minDislikes { get; set; }
        public int? maxDislikes { get; set; }
        public int? minComments { get; set; }
        public int? maxComments { get; set; }
        public DateTime? minDate { get; set; }
        public DateTime? maxDate { get; set; }
    }
}
