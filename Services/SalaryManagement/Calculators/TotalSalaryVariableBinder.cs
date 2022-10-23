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
                Description = "Khoảng thời gian trễ khi checkin trong một ca làm việc của nhân viên",
                DataType = VariableDataType.Decimal,
            },

            new SalarySystemVariable
            {
                Name = "total_allowance",
                Description = "Khoảng thời gian sớm khi checkout trong một ca làm việc của nhân viên.",
                DataType= VariableDataType.Decimal,
            },

            new SalarySystemVariable
            {
                Name = "total_bonus",
                Description = "Xác định nhân viên đã check in hay chưa.",
                DataType = VariableDataType.Decimal,
            },

            new SalarySystemVariable
            {
                Name = "salary_after_tk_calc",
                Description = "Lương của nhân viên sau khi đã trừ các khoản chấm công",
                DataType = VariableDataType.Decimal,
            },

            new SalarySystemVariable
            {
                Name = "total_ot_shifts_salary",
                Description = "Tổng lương nhận được từ thời gian ot",
                DataType = VariableDataType.Decimal,
            },

            new SalarySystemVariable
            {
                Name = "total_fixed_shifts_salary",
                Description = "Tổng lương nhận được từ các ca làm việc thông thường",
                DataType = VariableDataType.Decimal,
            },

            new SalarySystemVariable
            {
                Name = "num_work_days",
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
                    expression.Bind(variable, getTotalDeduction());
                    break;
                case "total_allowance":
                    expression.Bind(variable, getTotalAllowance());
                    break;
                case "total_bonus":
                    expression.Bind(variable, getTotalBonus());
                    break;
                case "salary_after_tk_calc":
                    expression.Bind(variable, getTotalSalaryAfterTimekeepingCalculation());
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
                .Where(x => x.Type == WorkingShiftEventType.FIXED_SHIFT)
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
