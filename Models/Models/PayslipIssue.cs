namespace Models.Models
{
    public class PayslipIssue
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Content { get; set; } = String.Empty;
        public bool IsResolved { get; set; }
        public int? CreatedById { get; set; }
        public int? ResolvedById { get; set; }
        public int? PayslipId { get; set; }
        public Payslip? Payslip { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public List<PayslipIssueComment> Comments { get; set; } = new List<PayslipIssueComment>();
        public User? CreatedBy { get; set; }
        public User? ResolvedBy { get; set; }
    }
}
