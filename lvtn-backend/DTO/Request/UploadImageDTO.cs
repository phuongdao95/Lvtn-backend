namespace lvtn_backend.DTO.Request
{
    public class UploadImageDTO
    {
        public string IdUser { get; set; }
        public string ImageName { get; set; }
        public string[] ImageData { get; set; }
    }
}
