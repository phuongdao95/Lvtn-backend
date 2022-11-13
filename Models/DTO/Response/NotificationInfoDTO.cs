namespace Models.DTO.Response
{
    public class NotificationInfoDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Message { get; set; }
        public bool? IsGlobal { get; set; }
        public bool? IsRead { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
