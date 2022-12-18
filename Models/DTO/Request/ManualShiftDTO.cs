namespace Models.DTO.Request
{
    public class ManualShiftDTO
    {
        public int TimekeepingId { get; set; }
        public DateTime CheckinTime { get; set; }
        public DateTime CheckoutTime { get; set; }
    }
}
