using System;

namespace Beer2Beer.Models
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
