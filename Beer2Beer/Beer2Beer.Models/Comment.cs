namespace Beer2Beer
{
    public class Comment: BaseEntity
    {
        public string Content { get; set; }
        public int PostID { get; set; }
        public Post Post { get; set; }
    }
}
