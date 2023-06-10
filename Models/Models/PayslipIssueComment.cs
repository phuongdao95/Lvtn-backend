namespace Models.Models
{
    public class PayslipIssueComment
    {
        public int Id { get; set; } 
        public string Content { get; set; } = string.Empty;
        public int? IssueId { get; set; }
        public int? UserId { get; set; }
        public PayslipIssue? Issue { get; set; }
        public User? User { get; set; }
        public DateTime? CreatedAt{ get; set; }
    }
}
