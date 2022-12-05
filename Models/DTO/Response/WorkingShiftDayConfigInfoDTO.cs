using Models.Enums;

namespace Models.DTO.Response
{
    public class WorkingShiftDayConfigInfoDTO
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public WorkingShiftDayConfigType Type { get; set; }
    }
}
