namespace Models.DTO.Response
{
    public class UploadImageResponseDTO
    {
        public bool IsUser { get; set; }
        public string Name { get; set; }
        public WorkingShiftTimekeepingInfo? response { get; set; }
    }
}
