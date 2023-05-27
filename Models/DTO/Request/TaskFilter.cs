namespace Models.DTO.Request
{
    public class TaskFilterDTO
    {
        public bool IsDisabled { get; set; }
        public List<int>? InchargeIds { get; set; }
        public List<int>? ReportToIds { get; set; }
        public List<int>? LabelIds { get; set; }
        public List<string>? Options { get; set; }
        public string? TaskType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
