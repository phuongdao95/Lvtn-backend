namespace Models.Models
{
    public class WorkingShiftUser
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public WorkingShift? WorkingShift { get; set; }
        public int UserId { get; set; }
        public int WorkingShiftEventId { get; set; }
    }
}
