using Models.Enums;
using Models.Models;

namespace Models.DTO.Request
{
    public class WorkingShiftTimekeepingHistoryDTO
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsCheckIn { get; set; }
        public int TimekeepingId { get; set; }
        public WorkingShiftTimekeepingDTO? Timekeeping { get; set; }
    }
}
