using Models.Enums;

namespace Models.Models
{
    public class WorkflowComment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkflowId { get; set; }
        public string? Comment { get; set; }
        public CommentStatus Status { get; set; } = CommentStatus.None;
        public bool RegularComment { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

        public User User { get; set; }
        public Workflow Workflow { get; set; }
    }
}
