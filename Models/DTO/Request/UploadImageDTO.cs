namespace Models.DTO.Request
{
    public class UploadImageDTO
    {
        public string ImageName { get; set; }
        public string[] ImageData { get; set; }
        public WorkingShiftTimekeepingDTO? dto { get; set;}
    }
}
