using Models.Enums;

namespace Models.Models
{
    public class WorkingShiftDayConfig
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public WorkingShiftDayConfigType Type { get; set; }
    }
}
