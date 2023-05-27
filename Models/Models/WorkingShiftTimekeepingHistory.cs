namespace Models.Models
{
    public class WorkingShiftTimekeepingHistory
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsCheckIn { get; set; }
        public int TimekeepingId { get; set; }
        public WorkingShiftTimekeeping? Timekeeping { get; set; }
        //public bool? isManageModify { get; set; }
    }
}
