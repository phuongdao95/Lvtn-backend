namespace Models.Models
{
    public class BaseEntity
    {
        public int CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UpdatedById { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
