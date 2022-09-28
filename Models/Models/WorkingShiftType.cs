namespace Models.Models
{
    public class WorkingShiftType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal Coeficient { get; set; }
        public List<WorkingShift>? WorkingShifts{ get; set; }
    }
}
