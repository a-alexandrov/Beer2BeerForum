using System.ComponentModel.DataAnnotations;

namespace Beer2Beer.DTO
{
    public class PostUpdateDto
    {
        [Required]
        public int UserID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }
    }
}
