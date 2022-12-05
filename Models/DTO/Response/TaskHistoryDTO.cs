namespace Models.DTO.Response
{
    public class TaskHistoryDTO
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? Message { get; set; }
        public int? TaskHistoryId { get; set; }
        public int? TaskLabelHistoryId { get; set; }
        public int? TaskCommentHistoryId { get; set; }
        public int? TaskFileHistoryId { get; set; }
        public string? Action { get; set; }
        public DateTime DateTime { get; set; }
    }
}
