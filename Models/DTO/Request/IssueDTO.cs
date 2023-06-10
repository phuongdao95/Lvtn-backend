namespace Models.DTO.Request
{
    public class IssueDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Content { get; set; } = string.Empty;
        public int UserId { get; set; }

    }
}
