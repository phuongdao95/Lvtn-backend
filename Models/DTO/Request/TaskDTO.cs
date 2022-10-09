namespace Models.DTO.Request
{
    public class TaskDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Point { get; set; }
        public DateTime? Deadline { get; set; }
        public int? EmployeeId { get; set; }
        public int? ColumnId { get; set; }
        public List<int>? TaskLabelIds { get; set; }
    }
}
