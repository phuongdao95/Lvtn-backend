namespace Models.DTO.Request
{
    public class WorkingShiftTimekeepingDTO
    {
        public int Id { get; set; }
        public bool DidCheckIn { get; set; }
        public DateTime? CheckinTime { get; set; }
        public bool DidCheckout { get; set; }
        public DateTime? CheckoutTime { get; set; }
        public int? EmployeeId { get; set; }
        public UserDTO? Employee { get; set; }
        public int? WorkingShiftEventId { get; set; }
        public WorkingShiftEventDTO? WorkingShiftEvent { get; set; }
        public bool? isCheckInFirst { get; set; }
        public bool? isCheckOutLast { get; set; }
        public bool? isCheckInInBetween { get; set; }
        public int? Offset { get; set; }
    }
}
