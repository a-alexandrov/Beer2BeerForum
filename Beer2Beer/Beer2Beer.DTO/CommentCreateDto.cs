using System.ComponentModel.DataAnnotations;

namespace Beer2Beer.DTO
{
    public class CommentCreateDto
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public int PostID { get; set; }

        [Required]
        public int UserID { get; set; }
    }
}
