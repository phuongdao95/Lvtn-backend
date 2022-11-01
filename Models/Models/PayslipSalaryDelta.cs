using Models.Enums;

namespace Models.Models
{
    public class PayslipSalaryDelta
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public int? GroupId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public SalaryDeltaType SalaryDeltaType { get; set; }
        public DateTime FromMonth { get; set; }
        public DateTime ToMonth { get; set; }
        public decimal Amount { get; set; }
        public string? FormulaDefine { get; set; }
        public int? PayslipId { get; set; }
        public Payslip? Payslip { get; set; }
    }
}
