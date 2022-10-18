namespace Beer2Beer.Models
{
    public class Like
    {
        public int ID { get; set; }

        public int UserId { get; set; }

        public bool? IsLiked { get; set; } = null;

        public int PostID { get; set; }
        public Post Post { get; set; }
    }
}
