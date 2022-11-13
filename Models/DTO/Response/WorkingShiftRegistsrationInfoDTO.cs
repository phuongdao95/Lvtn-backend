using Models.Enums;

namespace Models.DTO.Response
{
    public class WorkingShiftRegistrationInfoDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? GroupName { get; set; }
        public string? WorkingShiftName { get; set; }
        public string? WorkingShiftDescription { get; set; }
        public DateTime WorkingShiftStartTime { get; set; }
        public DateTime WorkingShiftEndTime { get; set; }
        public string? WorkingShiftFormulaName { get; set; }
        public WorkingShiftType WorkingShiftType { get; set; }
    }
}
