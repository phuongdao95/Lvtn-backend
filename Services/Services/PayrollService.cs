using AutoMapper;
using Models.DTO.Request;
using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using org.matheval;
using Services.Contracts;

namespace Services.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly IMapper _mapper;
        private readonly EmsContext _context;
        private readonly ISalaryCalculatorService _salaryCalculatorService;
        public PayrollService(
            IMapper mapper,
            EmsContext context, 
            ISalaryCalculatorService salaryCalculatorService)
        {
            _mapper = mapper;
            _context = context;
            _salaryCalculatorService = salaryCalculatorService;
        }

        public void CreatePayroll(PayrollDTO payrollDTO)
        {
            _salaryCalculatorService.CalculateSalaryAndWritePayslipsIntoDatabase(payrollDTO);
        }
        public void DeletePayroll(int id)
        {
            var payroll = _context.Payrolls.Find(id);

            if (payroll == null)
            {
                throw new Exception("Cannot delete payroll of null");
            }

            _context.Payrolls.Remove(payroll);
            _context.SaveChanges();
        }

        public void SendPayroll(int id)
        {
            var payroll = _context.Payrolls.Find(id);

            if (payroll == null)
            {
                throw new Exception("Pay roll cannot be null");
            }

            payroll.Status = PayrollStatus.Sent;

            _context.Payrolls.Update(payroll);
            _context.SaveChanges();
        }

        public void UpdatePayroll(int id, PayrollDTO payrollDTO)
        {
            var payroll = _context.Payrolls.Find(id);

            if (payroll == null)
            {
                throw new Exception("Payroll DTO cannot be null");
            }

            payroll.Name = payrollDTO.Name;
            payroll.Description = payrollDTO.Description;
            payroll.Status = payrollDTO.Status;

            _context.Payrolls.Update(payroll);
            _context.SaveChanges();

        }

        public Payroll GetPayrollById(int id)
        {
            var payroll = _context.Payrolls.Find(id);
            if (payroll == null)
            {
                throw new Exception("Pay roll cannot be null");
            }

            return payroll;
        }

        public List<Payroll> GetPayrollList(int offset, int limit, string? query = "name", string? queryType = "")
        {
            return _context.Payrolls
                .Where(payroll => payroll.Name.Contains(query) ||
                    query.Contains(payroll.Name))
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        public int GetPayrollListCount(int offset, int limit, string? query = "name", string? queryType = "")
        {
            return GetPayrollList(offset, limit, query, queryType).Count();
        }

        public List<Payslip> GetPayslipListOfPayroll(
            int id,
            int offset = 0,
            int limit = 8,
            string? query = "name",
            string? queryType = "")
        {
            var payroll = _context.Payrolls.Find(id);
            if (payroll == null)
            {
                throw new Exception("Payroll cannot be null");
            }

            _context.Entry(payroll)
                .Collection(payroll => payroll.PayslipList)
                .Load();

            if (payroll.PayslipList == null)
            {
                return new List<Payslip>();
            }

            return payroll.PayslipList
                .Where(payslip => payslip.Employee.Name.Contains(query) ||
                    query.Contains(payslip.Employee.Name))
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        public int GetPayslipListOfPayrollCount(
            int id,
            int offset = 0,
            int limit = 8,
            string? query = "name",
            string? queryType = "")
        {
            var payslipList = GetPayslipListOfPayroll(id, offset, limit, query, queryType);
            return payslipList.Count();
        }

    }
}
