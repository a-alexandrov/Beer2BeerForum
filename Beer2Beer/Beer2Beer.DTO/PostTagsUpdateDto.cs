using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Beer2Beer.DTO
{
    public class PostTagsUpdateDto
    {
        [Required]
        public int UserID { get; set; }

        [Required]
        public List<string> Tags { get; set; }

        public bool AreTagsToBeAdded { get; set; }
    }
}
