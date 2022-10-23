namespace Models.Models
{
    public class TaskHistory
    {
        public int Id { get; set; }
        public int? ColumnId { get; set; }
        public string? ColumnName { get; set; }
        public string? Name { get; set; }
        public int? InChargeId { get; set; }
        public string? InChargeName { get; set; }
        public int? ReportToId { get; set; }
        public string? ReportToName { get; set; }

    }
}
