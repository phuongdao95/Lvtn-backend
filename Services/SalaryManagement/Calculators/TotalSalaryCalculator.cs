using Models.Models;
using Models.Repositories.DataContext;
using org.matheval;

namespace Services.SalaryManagement.Calculators
{
    public class TotalSalaryCalculator
    {
        private User _user;
        private List<Group> _groups;
        private List<WorkingShiftTimekeeping> _timekeepings;
        private List<SalaryDelta> _salaryDeltas;
        private EmsContext _context;
        private DateTime _startOfMonth;
        private DateTime _endOfMonth;
        private UserVariableBinder _userVariableBinder;
        private SalaryVariableBinder _salaryVariableBinder;
        public TotalSalaryCalculator(
            EmsContext context,
            User user,
            int month, int year)
        {
            _context = context;
            _user = user;
            _startOfMonth = new DateTime(year, month, 1, 0, 0, 2);
            _endOfMonth = new DateTime(year, month,
                DateTime.DaysInMonth(year, month), 23, 59, 59);
            _groups = initializeGroups();
            _timekeepings = initializeTimekeepingsAndTheirShifts();
            _userVariableBinder = new UserVariableBinder(_context, _user);
            _salaryVariableBinder = new SalaryVariableBinder(_context);
        }

        private List<WorkingShiftTimekeeping> initializeTimekeepingsAndTheirShifts()
        {
            _context.Entry(_user).Collection(u => u.Timekeepings).Load();

            if (_user.Timekeepings == null)
            {
                throw new Exception("Unable to initialize timekeepings");
            }

            foreach (var tk in _user.Timekeepings)
            {
                _context.Entry(tk).Reference(tk => tk.WorkingShiftEvent).Load();
            }

            return _user.Timekeepings;
        }

        private List<Group> initializeGroups()
        {
            _context.Entry(_user).Collection(u => u.Groups).Load();
            if (_user.Groups == null)
            {
                throw new Exception("Unable to initialize groups");
            }

            return _user.Groups;
        }

        public Payslip CalculateSalary()
        {
            var payslip = new Payslip();

            payslip.EmployeeId = _user.Id;
            payslip.Name = _user.Name;
            payslip.BaseSalary = _user.BaseSalary;

            payslip.Timekeepings = calculateSalaryTimekeepings();
            payslip.SalaryDeltas = calculateSalaryDelta();
            payslip.ActualSalary = calculateActualSalary(payslip);

            return payslip;
        }

        private List<PayslipSalaryDelta> calculateSalaryDelta()
        {
            var salaryDeltaResult = new List<PayslipSalaryDelta>();

            var groupIds = _groups.Select(gr => gr.Id).ToList();

            var salaryDeltaList = _context.SalaryDeltas
                .Where(sd => groupIds.Contains(sd.GroupId))
                .Where(sd => sd.FromMonth <= _startOfMonth &&
                    sd.ToMonth >= _endOfMonth)
                .ToList();


            foreach (var salaryDelta in salaryDeltaList)
            {
                var salaryDeltaCalculator = new
                    SalaryDeltaCalculator(_context, _user, salaryDelta);

                salaryDeltaResult.Add(salaryDeltaCalculator.Calculate());
            }

            return salaryDeltaResult;
        }

        private List<PayslipWorkingShiftTimekeeping> calculateSalaryTimekeepings()
        {
            var timekeepingResult = new List<PayslipWorkingShiftTimekeeping>();

            var timekeepingList = _timekeepings
                .Where(tk =>
                    tk.WorkingShiftEvent.StartTime > _startOfMonth
                    && tk.WorkingShiftEvent.EndTime < _endOfMonth)
                .ToList();

            foreach (var timekeeping in timekeepingList)
            {
                var tkCalculator = new TimekeepingCalculator(_user, _context, timekeeping);

                timekeepingResult.Add(tkCalculator.CalculateSalary());
            }

            return timekeepingResult;
        }

        private decimal calculateActualSalary(Payslip payslip)
        {
            var groupIds = _groups.Select(gr => gr.Id).ToList();

            var salaryGroup = _context.SalaryGroups
                .Where(x => groupIds.Contains(x.GroupId))
                .OrderByDescending(x => x.Priority)
                .FirstOrDefault();

            if (salaryGroup == null)
            {
                throw new Exception("User has no salary group");
            }

            var formula = _context.SalaryFormulas
                .Where(x => x.Name == salaryGroup.FormulaName)
                .Single();

            payslip.FormulaName = formula.DisplayName;
            payslip.FormulaDefine = formula.Define;

            if (formula == null)
            {
                throw new Exception("Formula not found");
            }

            var expression = new Expression(formula.Define);

            var salaryBinder = new TotalSalaryVariableBinder(
                _context, _user, payslip);

            foreach (var variable in expression.getVariables())
            {
                if (salaryBinder.ContainsVariable(variable))
                {
                    salaryBinder.BindExpression(expression, variable);
                }
                else if (_userVariableBinder.ContainsVariable(variable))
                {
                    _userVariableBinder.BindExpression(expression, variable);
                }
                else
                {
                    _salaryVariableBinder.BindExpression(expression, variable);
                }
            }

            return expression.Eval<decimal>();
        }
    }
}
