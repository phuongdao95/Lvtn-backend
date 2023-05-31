using Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Task : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public TaskType Type { get; set; }
        public string? Description { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Point { get; set; }
        public int? InChargeId { get; set; }
        public int? ReportToId { get; set; }
        public int? Order { get; set; }
        public int? ParentTaskId { get; set; }
        public DateTime? DoneAt { get; set; }
        public float? Estimated { get; set; }
        public bool? IsReopen { get; set; } = false;
        public int? ColumnId { get; set; }
        public Task? ParentTask { get; set; }
        public TaskColumn? Column { get; set; }
        public User? InCharge { get; set; }
        public User? ReportTo { get; set; }
        public List<Task>? SubTasks { get; set; }
        public List<TaskLabel>? Labels { get; set; }
        public List<TaskComment>? Comments { get; set; }
        public List<TaskFile>? Files { get; set; }
        public List<TaskHistory>? TaskHistories { get; set; }
    }
}
