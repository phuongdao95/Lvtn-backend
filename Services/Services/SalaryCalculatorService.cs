using Models.DTO.Request;
using Models.Models;
using Models.Repositories.DataContext;
using Services.SalaryManagement.Calculators;
using Expression = org.matheval.Expression;

namespace Services.Services
{
    public class SalaryCalculatorService
    {
        private EmsContext _context;

        public SalaryCalculatorService(EmsContext context)
        {
            _context = context;
        }

        public Payroll CalculateUserSalaryAndWriteIntoDatabases(
            PayrollDTO payrollDTO)
        {
            var result = new Payroll();
            var users = _context.Users.ToList();
            var startTime = new DateTime(payrollDTO.Year, payrollDTO.Month, 1, 0, 0, 2);
            var endTime = new DateTime(payrollDTO.Year, payrollDTO.Month,
                DateTime.DaysInMonth(payrollDTO.Year, payrollDTO.Month), 23, 59, 59);

            result.PayslipList = new List<Payslip>();
            result.Name = payrollDTO.Name;
            result.Description = payrollDTO.Description;
            result.FromDate = startTime;
            result.ToDate = endTime;

            foreach (var user in users)
            {
                var payslip = new Payslip();
                try
                {
                    var salaryCalculator = new TotalSalaryCalculator(
                        _context, user, payrollDTO.Month, payrollDTO.Year);

                    payslip = salaryCalculator.CalculateSalary();
                    payslip.Name = payrollDTO.Name;
                    payslip.Description = payrollDTO.Description;
                    payslip.Month = payrollDTO.Month;
                    payslip.Year = payrollDTO.Year;
                    payslip.CalculatedSuccess = true;
                }
                catch (Exception)
                {
                    payslip.CalculatedSuccess = false;
                }

                result.PayslipList.Add(payslip);
            }
            
            _context.Payrolls.Add(result);
            _context.SaveChanges();
            return result;
        }
    }
}
