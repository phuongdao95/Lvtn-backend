using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class TaskCommentHistory : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public int TaskCommentId { get; set; }
        public string? UserName { get; set; }
        public string? Message { get; set; }
        public int? TaskHistoryId { get; set; }
        public TaskHistory? TaskHistory { get; set; }
    }
}
