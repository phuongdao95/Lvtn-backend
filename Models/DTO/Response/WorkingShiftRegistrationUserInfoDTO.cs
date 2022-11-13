using Models.Enums;

namespace Models.DTO.Response
{
    public class WorkingShiftRegistrationUserInfoDTO
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public string? UserName { get; set; }
        public string? WorkingShiftName { get; set; }
        public string? WorkingShiftDescription { get; set; }
        public WorkingShiftType? WorkingShiftType { get; set; }
        public DateTime? RegistrationStartTime { get; set; }
        public DateTime? RegistrationEndTime { get; set; }
    }
}
