namespace Models.DTO.Request
{
    public class CreateOrUpdateOverTimeShiftDTO
    {
        public string? Name { get; set; }
        public int GroupId { get; set; }
        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? FormulaName { get; set; }
        public string? Description { get; set; }
    }
}
