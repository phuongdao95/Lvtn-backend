using Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class WorkingShift
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public string? FormulaName { get; set; }
        [Required]
        public WorkingShiftType Type { get; set; }
        public int? WorkingShiftRegistrationId { get; set; }
        public WorkingShiftRegistration? WorkingShiftRegistration { get; set; }
        public List<WorkingShiftTimekeeping>? Timekeepings{ get; set; }
        public List<User>? Users { get; set; }
    }
}
