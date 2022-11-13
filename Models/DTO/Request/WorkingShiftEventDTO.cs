namespace Models.DTO.Request
{
    public class WorkingShiftEventDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? FormulaName { get; set; }
        public int? userId { get; set; }
        public List<UserDTO>? Users { get; set; }
        public Boolean? isCheck { get; set; }
    }
}
