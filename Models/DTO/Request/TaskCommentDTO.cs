namespace Models.DTO.Request
{
    public class TaskCommentDTO
    {
        public string? Message { get; set; }
        public int? TaskId { get; set; }
        public int? UserId { get; set; }
    }
}
