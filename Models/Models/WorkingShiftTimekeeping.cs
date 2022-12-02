using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class WorkingShiftTimekeeping
    {
        [Key]
        public int Id { get; set; }
        public bool DidCheckIn { get; set; }
        public bool DidCheckout { get; set; }
        public DateTime? CheckinTime { get; set; }
        public DateTime? CheckoutTime { get; set; }
        public int? WorkingShiftEventId { get; set; }
        public int? EmployeeId { get; set; }
        public User? Employee { get; set; }
        public WorkingShift? WorkingShiftEvent { get; set; }
        public List<WorkingShiftTimekeepingHistory> TimekeepingHistories { get; set; }

        public WorkingShiftTimekeeping()
        {
            TimekeepingHistories = new List<WorkingShiftTimekeepingHistory>();
        }
    }
}
