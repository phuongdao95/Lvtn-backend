namespace Models.DTO.Response
{
    public class PayslipInfoDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? BaseSalary { get; set; }
        public decimal? ActualSalary { get; set; }
        public string? FormulaName { get; set; }
        public string? FormulaDefine { get; set; }
        public decimal? SalaryAfterTimekeeepingCalculation { get; set; }
        public decimal? TotalDeduction { get; set; }
        public decimal? TotalAllowance { get; set; }
        public decimal? TotalBonus { get; set; }
        public string? Description { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeId { get; set; }
        public string? PayrollName { get; set; }
        public string? PayrollId { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
    }
}
