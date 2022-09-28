using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Payslip
    {
        [Key]
        public int Id { get; set; }
        public decimal BaseSalary { get; set; }
        public string? Description { get; set; }
        public int? EmployeeId { get; set; }
        public int? PayrollId { get; set; }
        public User? Employee { get; set; }
        public Payroll? Payroll { get; set; }
    }
}
