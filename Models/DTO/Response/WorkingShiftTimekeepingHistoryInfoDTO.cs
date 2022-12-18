namespace Models.DTO.Response
{
    public class WorkingShiftTimekeepingHistoryInfoDTO
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsCheckIn { get; set; }
        public int TimekeepingId { get; set; }
        public WorkingShiftTimekeepingInfoDTO? Timekeeping { get; set; }
    }
}
