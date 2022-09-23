namespace Beer2Beer
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
