using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using org.matheval;

namespace Services.SalaryManagement.Calculators
{
    public class TotalSalaryVariableBinder
    {

        private static List<SalarySystemVariable> _systemVariables =
            new List<SalarySystemVariable>()
        {
            new SalarySystemVariable
            {
                Name = "total_deduction",
                DisplayName = "Tổng khấu trừ",
                Description = "Tổng khấu trừ trong tháng của nhân viên",
                DataType = VariableDataType.Decimal,
            },

            new SalarySystemVariable
            {
                Name = "total_allowance",
                DisplayName = "Tổng phụ cấp",
                Description = "Tổng phụ cấp trong tháng của nhân viên",
                DataType= VariableDataType.Decimal,
            },

            new SalarySystemVariable
            {
                Name = "total_bonus",
                DisplayName = "Tổng thưởng",
                Description = "Tổng thưởng trong tháng của nhân viên",
                DataType = VariableDataType.Decimal,
            },

            new SalarySystemVariable
            {
                Name = "salary_after_tk_calc",
                DisplayName = "Tổng lương sau chấm công",
                Description = "Lương của nhân viên sau khi đã trừ các khoản phạt do chấm công",
                DataType = VariableDataType.Decimal,
            },

            new SalarySystemVariable
            {
                Name = "total_ot_shifts_salary",
                DisplayName =  "Tổng lương OT",
                Description = "Tổng lương nhận được từ thời gian ot",
                DataType = VariableDataType.Decimal,
            },

            new SalarySystemVariable
            {
                Name = "total_fixed_shifts_salary",
                DisplayName = "Tổng lương fixed shift",
                Description = "Tổng lương nhận được từ các ca làm việc thông thường",
                DataType = VariableDataType.Decimal,
            },

            new SalarySystemVariable
            {
                Name = "num_work_days",
                DisplayName = "Số ngày làm việc trong tháng",
                Description = "Số ngày làm việc (không tính ot) trong tháng",
                DataType = VariableDataType.Integer
            }
        };


        private EmsContext _context;
        private User _user;
        private Payslip _payslip;
        public TotalSalaryVariableBinder(EmsContext context,
            User user, Payslip calculatedPayslip)
        {
            _context = context;
            _user = user;
            _payslip = calculatedPayslip;
        }

        public void BindExpression(Expression expression, string variable)
        {
            if (!ContainsVariable(variable))
            {
                throw new Exception("Variable not found");
            }

            switch (variable)
            {
                case "total_deduction":
                    var totalDeduction = getTotalDeduction();
                    _payslip.TotalDeduction = totalDeduction;
                    expression.Bind(variable, totalDeduction);
                    break;
                case "total_allowance":
                    var totalAllowance = getTotalAllowance();
                    _payslip.TotalAllowance = totalAllowance;
                    expression.Bind(variable, totalAllowance);
                    break;
                case "total_bonus":
                    var totalBonus = getTotalBonus();
                    _payslip.TotalBonus = totalBonus;
                    expression.Bind(variable, totalBonus);
                    break;
                case "salary_after_tk_calc":
                    var salaryAfterTimekeepingCalculation = getTotalSalaryAfterTimekeepingCalculation();
                    _payslip.SalaryAfterTimekeeepingCalculation = salaryAfterTimekeepingCalculation;
                    expression.Bind(variable, salaryAfterTimekeepingCalculation);
                    break;
                case "num_work_days":
                    expression.Bind(variable, getNumberOfWorkDays());
                    break;
            }
        }

        private int getNumberOfWorkDays()
        {
            if (_payslip.Timekeepings == null)
            {
                throw new Exception();
            }

            return _payslip.Timekeepings
                .Where(x => x.Type == WorkingShiftType.FIXED_SHIFT)
                .Count();
        }

        public bool ContainsVariable(string variable)
        {
            return _systemVariables.Any(x => x.Name == variable);
        }

        private decimal getTotalDeduction()
        {
            return getTotalOfSalaryDelta(SalaryDeltaType.Deduction);
        }

        private decimal getTotalAllowance()
        {
            return getTotalOfSalaryDelta(SalaryDeltaType.Allowance);
        }

        private decimal getTotalBonus()
        {
            return getTotalOfSalaryDelta(SalaryDeltaType.Bonus);
        }

        private decimal getTotalSalaryAfterTimekeepingCalculation()
        {
            if (_payslip.Timekeepings == null)
            {
                throw new Exception();
            }

            return _payslip.Timekeepings
                .Aggregate(0m, (acc, tk) => acc + tk.Amount);
        }

        private decimal getTotalOfSalaryDelta(SalaryDeltaType type)
        {
            if (_payslip.SalaryDeltas == null)
            {
                throw new Exception();
            }

            var salaryDeltaList = _payslip.SalaryDeltas
                .Where(x => x.SalaryDeltaType == type)
                .ToList();

            return salaryDeltaList
                .Aggregate(0m, (acc, salaryDelta) => acc + salaryDelta.Amount);
        }

        public static List<SalarySystemVariable> GetSystemVariables()
        {
            return _systemVariables.Concat(
                UserVariableBinder.GetSystemVariables())
                .ToList();
        }
    }
}
