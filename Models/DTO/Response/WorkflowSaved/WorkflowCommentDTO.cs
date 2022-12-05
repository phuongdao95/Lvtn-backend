namespace Models.DTO.Response.WorkflowSaved
{
    public class WorkflowCommentDTO
    {
        public string Name { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Text { get; set; }
        public long TimeLong => (long)TimeStamp.
                                    ToUniversalTime().
                                    Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).
                                    TotalMilliseconds;
    }
}
