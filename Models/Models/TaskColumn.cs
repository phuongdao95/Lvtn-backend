using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class TaskColumn
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int? BoardId { get; set; }
        public int? Order { get; set; }
        public string? Description { get; set; }
        public TaskBoard? Board { get; set; }
        public List<Task>? Tasks { get; set; }
    }
}
