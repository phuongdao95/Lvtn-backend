using Models.Enums;

namespace Models.Models
{
    public class TaskHistory : BaseEntity
    {
        public int Id { get; set; }
        public TaskHistoryAction Action { get; set; }
        public int? ColumnId { get; set; }
        public string? Description { get; set; }
        public string? ColumnName { get; set; }
        public string? Name { get; set; }
        public int? InChargeId { get; set; }
        public string? InChargeName { get; set; }
        public int? ReportToId { get; set; }
        public string? ReportToName { get; set; }
        public int TaskId { get; set; }
        public Task? Task { get; set; }
        public DateTime? DateTime { get; set; }
        public TaskFileHistory? TaskFileHistory { get; set; }
        public TaskCommentHistory? TaskCommentHistory { get; set; }
        public TaskLabelHistory? TaskLabelHistory { get;set; }
    }
}
