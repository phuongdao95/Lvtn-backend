using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class WorkingShiftTimekeeping
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public bool DidCheckIn { get; set; }
        public DateTime? CheckinTime { get; set; }
        [Required]
        public bool DidCheckout { get; set; }
        public int? WorkingShiftEventId { get; set; }
        public DateTime? CheckoutTime { get; set; }
        [Required]
        public int? EmployeeId { get; set; }
        public User? Employee { get; set; }
        public WorkingShiftEvent? WorkingShiftEvent { get; set; }
    }
}
