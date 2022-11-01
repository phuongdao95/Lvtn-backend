namespace Models.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? DateTime { get; set; }
        public List<User> Users { get; set; }

        public Notification()
        {
            Users = new List<User>();
        }
    }
}
