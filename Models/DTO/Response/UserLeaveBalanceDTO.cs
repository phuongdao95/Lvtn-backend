namespace Models.DTO.Response
{
    public class UserLeaveBalanceDTO
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public List<LeaveBalanceDTO>? LeaveBalances { get; set; }
    }
}
