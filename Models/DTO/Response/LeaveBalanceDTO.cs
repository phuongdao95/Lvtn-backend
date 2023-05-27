namespace Models.DTO.Response
{
    public class LeaveBalanceDTO
    {
        public decimal TotalDays { get; set; }
        public decimal TakenDays { get; set; }
        public int Year { get; set; }
        public int LeaveId { get; set; }
    }
}
