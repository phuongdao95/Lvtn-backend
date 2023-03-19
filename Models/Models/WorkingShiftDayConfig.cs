using Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class WorkingShiftDayConfig
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public WorkingShiftDayConfigType Type { get; set; }
    }
}
