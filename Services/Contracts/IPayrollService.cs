using Models.DTO.Request;
using Models.Models;

namespace Services.Contracts
{
    public interface IPayrollService
    {
        void CreatePayroll(PayrollDTO payrollDTO);
        void UpdatePayroll(int id, PayrollDTO payrollDTO);
        void DeletePayroll(int id);
        void SendPayroll(int id);

        public Payroll GetPayrollById(int id);
        public List<Payroll> GetPayrollList(int offset, int limit, string? query = "name", string? queryType = "");
        public int GetPayrollListCount(int offset, int limit, string? query = "name", string? queryType = "");

        public List<Payslip> GetPayslipListOfPayroll(int id, int offset = 0, int limit = 8, string? query = "name", string? queryType = "");
        public int GetPayslipListOfPayrollCount(int id, int offset = 0, int limit = 8, string? query = "name", string? queryType = "");
    }
}
