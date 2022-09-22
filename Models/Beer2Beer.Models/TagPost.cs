namespace Beer2Beer
{
    public class TagPost
    {
        public int ID { get; set; }
        public int TagID { get; set; }
        public Tag Tag { get; set; }
        public int PostID { get; set; }
        public Post Post { get; set; }
    }
}
