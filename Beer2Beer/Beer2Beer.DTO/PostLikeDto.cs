namespace Beer2Beer.DTO
{
    public class PostLikeDto
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public bool IsLiked { get; set; }
    }
}
