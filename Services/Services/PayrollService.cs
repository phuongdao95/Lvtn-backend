using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.DTO.Request;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;

namespace Services.Services
{
    public class PayrollService : IPayrollService
    {
        private readonly IMapper _mapper;
        private readonly EmsContext _context;
        private readonly SalaryCalculatorService _salaryCalculatorService;
        public PayrollService(
            IMapper mapper,
            EmsContext context,
            SalaryCalculatorService salaryCalculatorService)
        {
            _mapper = mapper;
            _context = context;
            _salaryCalculatorService = salaryCalculatorService;
        }

        public void CreatePayroll(PayrollDTO payrollDTO)
        {
            _salaryCalculatorService.CalculateUserSalaryAndWriteIntoDatabases(payrollDTO);
        }

        public void SendPayroll(int payrollId)
        {
            var payroll = _context.Payrolls.Find(payrollId);
            if (payroll == null)
            {
                throw new Exception("Payroll not found");
            }

            payroll.Status = PayrollStatus.Sent;
            _context.Payrolls.Update(payroll);
            _context.SaveChanges();
        }

        public List<Payslip> GetPayslipsOfPayroll(int payrollId)
        {
            var payroll = _context.Payrolls.Find(payrollId);
            if (payroll == null)
            {
                throw new Exception("Payroll is null");
            }

            _context.Entry(payroll).Collection(p => p.PayslipList).Load();

            foreach (var payslip in payroll.PayslipList)
            {
                _context.Entry(payslip).Reference(p => p.Employee).Load();
            }

            if (payroll.PayslipList == null)
            {
                return new List<Payslip>();
            }

            return payroll.PayslipList;
        }
        public void DeletePayroll(int id)
        {
            var payroll = _context.Payrolls.Where(payroll => payroll.Id == id)
                .Include(payroll => payroll.PayslipList)
                .Single();

            if (payroll == null)
            {
                throw new Exception("Cannot delete payroll of null");
            }

            if (payroll.PayslipList == null)
            {
                throw new Exception("Payroll not init properly");
            }

            foreach (var payslip in payroll.PayslipList)
            {
                _context.Entry(payslip).Collection(p => p.Timekeepings).Load();
                _context.Entry(payslip).Collection(p => p.SalaryDeltas).Load();
            }

            _context.Payrolls.Remove(payroll);
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


            return _context.Payslips
                .Where(payslip => payslip.PayrollId == id)
                .Include(p => p.Employee)
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

        public List<PayslipWorkingShiftTimekeeping> GetPayslipTimekeepings(int id)
        {
            var payslip = _context.Payslips.Where(x => x.Id == id)
                .Include(p => p.Timekeepings)
                .FirstOrDefault();

            if (payslip == null)
            {
                throw new Exception("Payslip not found");
            }

            if (payslip.Timekeepings == null)
            {
                throw new Exception("Timekeepings not initialized");
            }

            return payslip.Timekeepings;

        }
        public List<Payslip> GetPayslipsOfUser(int userId)
        {
            var user = _context.Users.Find(userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return _context.Payslips.Where(p => p.EmployeeId == userId)
                .Where(p => p.Payroll.Status == PayrollStatus.Sent)
                .ToList();
        }

        public Payslip GetPayslipById(int id)
        {
            var payslip = _context.Payslips.Where(p => p.Id == id)
                .Include(p => p.Employee)
                .Single();

            if (payslip == null)
            {
                throw new Exception("Payslip not found");
            }

            return payslip;
        }

        public List<PayslipSalaryDelta> GetPayslipSalaryDeltas(int id)
        {
            var payslip = _context.Payslips.Where(x => x.Id == id)
                .Include(p => p.SalaryDeltas)
                .FirstOrDefault();

            if (payslip == null)
            {
                throw new Exception("Payslip not found");
            }

            if (payslip.SalaryDeltas == null)
            {
                throw new Exception("SalaryDeltas not initialized");
            }

            return payslip.SalaryDeltas;
        }



    }
}
