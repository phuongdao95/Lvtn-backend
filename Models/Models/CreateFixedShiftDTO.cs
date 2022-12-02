namespace Models.Models
{
    public class CreateFixedShiftDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Month { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? FormulaName { get; set; }
        public int GroupId { get; set; }
        public List<bool>? WeekDayConfigs { get; set; }
    }
}
