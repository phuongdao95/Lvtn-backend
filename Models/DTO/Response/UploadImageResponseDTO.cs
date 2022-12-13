namespace Models.DTO.Response
{
    public class UploadImageResponseDTO
    {
        public bool IsUser { get; set; }
        public string Name { get; set; }
        public WorkingShiftTimekeepingHistoryInfoDTO? response { get; set; }
    }
}
