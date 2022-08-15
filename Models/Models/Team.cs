using System.ComponentModel.DataAnnotations.Schema;

namespace lvtn_backend.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Leader")]
        public int? LeaderId { get; set; }
        public int? DepartmentId { get; set; }

        public Department? Department { get; set; }
        public User? Leader { get; set; }
        public List<User>? Members { get; set; }
    }
}
