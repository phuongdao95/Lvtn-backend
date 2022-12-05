namespace Models.Models
{
    public class WorkingShiftRegistration
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int WorkingShiftId { get; set; }
        public int GroupId { get; set; }
        public WorkingShift? WorkingShift { get; set; }
        public List<User>? RegisteredUsers { get; set; }
        public Group? AllowedUserGroup { get; set; }
        public List<WorkingShiftRegistrationUser>? WorkingShiftRegistrationUsers { get; set; }
    }
}
