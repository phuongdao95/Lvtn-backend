namespace Models.Models
{
    public class PayslipTimekeeping
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? CheckinTime { get; set; }
        public DateTime? CheckoutTime { get; set; }
        public bool? DidCheckIn { get; set; }
        public bool? DidCheckOut { get; set; }
        public string? Formula { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
