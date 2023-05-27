namespace Models.DTO.Request
{
    public class ReopenTaskDTO
    {
        public string? Title { get; set; }
        public int Point { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int InChargeId { get; set; }
        public int ReportToId { get; set;}
    }
}
