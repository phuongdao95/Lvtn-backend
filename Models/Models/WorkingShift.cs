namespace Models.Models
{
    public class WorkingShift
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public bool IsCheckIn { get; set; }
        public DateTime Date { get; set; }
        public int? WorkingShiftTypeId { get; set; }
        public User? Employee { get; set; }
        WorkingShiftType? WorkingShiftType { get; set; }
    }
}
