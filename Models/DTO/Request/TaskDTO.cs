namespace Models.DTO.Request
{
    public class TaskDTO
    {
        public string? Name { get; set; }
        public int? Point { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? ColumnId { get; set; }
        public int? InChargeId { get; set; }
        public int? ReportToId { get; set; }
        public string? Description { get; set; }
        public List<int>? TaskLabelIds { get; set; }
    }
}
