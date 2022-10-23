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
        public int? EmployeeId { get; set; }
        public int? PayrollId { get; set; }
        public List<PayslipSalaryDelta>? SalaryDeltas { get; set; }
        public List<PayslipWorkingShiftTimekeeping>? Timekeepings { get; set; }
        public decimal? ActualSalary { get; set; }
        public User? Employee { get; set; }
        public Payroll? Payroll { get; set; }
    }
}
