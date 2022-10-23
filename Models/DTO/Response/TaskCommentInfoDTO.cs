namespace Models.DTO.Response
{
    public class TaskCommentInfoDTO
    {
        public int? Id { get; set; }
        public string? Message { get; set; }
        public int? TaskId { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserAvatarUrl { get; set; }
    }
}
