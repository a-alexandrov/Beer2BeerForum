using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Beer2Beer.DTO
{
    public class PostUpdateDto
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int UserID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public List<string> Tags { get; set; }
    }
}
