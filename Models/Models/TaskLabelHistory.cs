namespace Models.Models
{
    public class TaskLabelHistory : BaseEntity
    {
        public int Id { get; set; }
        public int TaskLabelId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? TaskHistoryId { get; set; }
        public TaskHistory? TaskHistory { get; set; }
    }
}
