using Models.Models;

namespace Repositories.DataContext.DataSeeder
{
    public class SalaryManagementDataSeeder : DataSeeder
    {

        private readonly List<Payroll> _payrollList;
        private readonly List<Payslip> _payslipList;
        private readonly List<SalaryDelta> _salaryDeltaList;
        private readonly List<SalaryDeltaFormula> _formulaList;
        private readonly List<SalaryDeltaVariable> _formulaConstantList;

        public SalaryManagementDataSeeder()
        {
            _salaryDeltaList = seedSalaryDeltaList();
            _formulaConstantList = seedSDFormulaConstantList();
            _formulaList = seedSDFormulaList();
            _payslipList = seedPayslipList();
            _payrollList = seedPayrollList();
        }

        private List<Payslip> seedPayslipList()
        {
            return new List<Payslip>();
        }

        private List<Payroll> seedPayrollList()
        {
            return new List<Payroll>();
        }

        private List<SalaryDelta> seedSalaryDeltaList()
        {
            return new List<SalaryDelta>();
        }

        private List<SalaryDeltaFormula> seedSDFormulaList()
        {
            return new List<SalaryDeltaFormula>();
        }

        private List<SalaryDeltaVariable> seedSDFormulaConstantList()
        {
            return new List<SalaryDeltaVariable>();
        }

        public void SeedData()
        {
            throw new NotImplementedException();
        }


    }
}
