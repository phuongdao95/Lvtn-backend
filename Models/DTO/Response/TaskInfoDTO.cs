namespace Models.DTO.Response
{
    public class TaskInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Point { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? InChargeId { get; set; }
        public string? InChargeName { get; set; }
        public string? InChargeAvatarUrl { get; set; }
        public int? ReportToId { get; set; }
        public string? ReportToName { get; set; }
        public int? ColumnId { get; set; }
        public string? ColumnName { get; set; }
        public string? Description { get; set; }
    }
}
