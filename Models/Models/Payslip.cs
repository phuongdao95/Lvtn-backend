using Models.DTO.Response;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Payslip
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal BaseSalary { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? FormulaName { get; set; }
        public string? FormulaDefine { get; set; }
        public decimal? SalaryAfterTimekeeepingCalculation { get; set; }
        public decimal? TotalAllowance { get; set; }
        public decimal? TotalBonus { get; set; }
        public decimal? TotalDeduction { get; set; }
        public int? EmployeeId { get; set; }
        public int? PayrollId { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public bool? CalculatedSuccess { get; set; }
        public List<PayslipIssue> Issues { get; set; } = new List<PayslipIssue>();
        public List<PayslipSalaryDelta>? SalaryDeltas { get; set; }
        public List<PayslipWorkingShiftTimekeeping>? Timekeepings { get; set; }
        public decimal? ActualSalary { get; set; }
        public User? Employee { get; set; }
        public Payroll? Payroll { get; set; }
    }
}
