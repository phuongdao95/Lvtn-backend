using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime? Deadline { get; set; }
        public int? EmployeeId { get; set; }
        public int? ColumnId { get; set; }
        public TaskColumn? Column { get; set; }
        public User? User { get; set; }
        public List<TaskLabel>? Labels { get; set; }
        public List<TaskComment>? Comments { get; set; }
    }
}
