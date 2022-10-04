using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class TaskBoard
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int TeamId { get; set; }
        public Team? Team { get; set; }
        public List<TaskColumn>? TaskColumns { get; set; }
    }
}
