namespace Beer2Beer.Models
{
    public class Admin : BaseEntity
    {
        public string PhoneNumber { get; set; }

        public User User { get; set; }
        public int UserID {get;set;}
    }
}
