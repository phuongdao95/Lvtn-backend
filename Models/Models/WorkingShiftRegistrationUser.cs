namespace Models.Models
{
    public class WorkingShiftRegistrationUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WorkingShiftRegistrationId { get; set; }
        public User? User { get; set; }
        public WorkingShiftRegistration? WorkingShiftRegistration { get; set; }
    }
}
