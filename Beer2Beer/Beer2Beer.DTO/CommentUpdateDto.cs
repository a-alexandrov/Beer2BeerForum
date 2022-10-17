using System.ComponentModel.DataAnnotations;

namespace Beer2Beer.DTO
{
    public class CommentUpdateDto
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
