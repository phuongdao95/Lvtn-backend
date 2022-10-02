namespace Models.Models
{
    public class Payroll
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public PayrollStatus Status { get; set; }
        public List<Payslip>? PayslipList { get; set; }
    }
}
