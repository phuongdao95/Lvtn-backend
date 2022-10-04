using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class TaskLabel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Task>? Tasks { get; set; }
    }
}
