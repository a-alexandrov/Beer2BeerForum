using System.ComponentModel.DataAnnotations;

namespace Beer2Beer.DTO
{
    public class PostCreateDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public int UserID { get; set; }
    }
}
