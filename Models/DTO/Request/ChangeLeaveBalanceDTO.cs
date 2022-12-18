namespace Models.DTO.Request
{
    public class ChangeLeaveBalanceDTO
    {
        public int UserId { get; set; }
        public int Year { get; set; }
        public int TotalDays { get; set; }
    }
}
