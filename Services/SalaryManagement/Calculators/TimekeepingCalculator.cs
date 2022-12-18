using Models.Models;
using Models.Repositories.DataContext;
using org.matheval;

namespace Services.SalaryManagement.Calculators
{
    public class TimekeepingCalculator
    {
        private readonly EmsContext _context;
        private readonly User _user;
        private readonly WorkingShiftTimekeeping _timekeeping;
        private readonly WorkingShift _workingShift;
        private readonly UserVariableBinder _userVariableBinder;
        private readonly SalaryVariableBinder _salaryVariableBinder;
        public TimekeepingCalculator(
            User user,
            EmsContext context,
            WorkingShiftTimekeeping timekeeping)
        {
            if (timekeeping.WorkingShiftEvent == null)
            {
                throw new Exception();
            }

            _user = user;
            _context = context;
            _timekeeping = timekeeping;
            _workingShift = initializeWorkingShift();
            _userVariableBinder = new UserVariableBinder(context, user);
            _salaryVariableBinder = new SalaryVariableBinder(context);
        }

        private WorkingShift initializeWorkingShift()
        {
            _context.Entry(_timekeeping)
                .Reference(tk => tk.WorkingShiftEvent)
                .Load();

            if (_timekeeping.WorkingShiftEvent == null)
            {
                throw new Exception();
            }

            return _timekeeping.WorkingShiftEvent;
        }

        public PayslipWorkingShiftTimekeeping CalculateSalary()
        {
            var formulaName = _workingShift.FormulaName;
            var formula = _context.SalaryFormulas.Where(x => x.Name == formulaName)
                .Single();

            if (formula == null)
            {
                return new PayslipWorkingShiftTimekeeping
                {
                    Amount = 0,
                    DidCheckIn = _timekeeping.DidCheckIn,
                    DidCheckout = _timekeeping.DidCheckout,
                    CheckinTime = _timekeeping.CheckinTime,
                    CheckoutTime = _timekeeping.CheckoutTime,
                    StartTime = _workingShift.StartTime,
                    EndTime = _workingShift.EndTime,
                    FormulaDefine = "!!invalid formula",
                    CalculatedSuccess = false,
                };
            }

            if (!_timekeeping.DidCheckout ||
                !_timekeeping.DidCheckout ||
                _timekeeping.CheckinTime == null ||
                _timekeeping.CheckinTime == null)
            {
                return new PayslipWorkingShiftTimekeeping
                {
                    Amount = 0,
                    DidCheckIn = _timekeeping.DidCheckIn,
                    DidCheckout = _timekeeping.DidCheckout,
                    CheckinTime = _timekeeping.CheckinTime,
                    CheckoutTime = _timekeeping.CheckoutTime,
                    StartTime = _workingShift.StartTime,
                    EndTime = _workingShift.EndTime,
                    FormulaDefine = formula.Define,
                    CalculatedSuccess = false,
                };
            }

            var expression = new Expression(formula.Define);

            foreach (var variable in expression.getVariables())
            {
                var binder = new TimekeepingVariableBinder(_context, _user, _timekeeping);

                if (binder.ContainsVariable(variable))
                {
                    binder.BindExpression(expression, variable);
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

            return new PayslipWorkingShiftTimekeeping()
            {
                Amount = expression.Eval<decimal>(),
                DidCheckIn = _timekeeping.DidCheckIn,
                DidCheckout = _timekeeping.DidCheckout,
                CheckinTime = _timekeeping.CheckinTime,
                CheckoutTime = _timekeeping.CheckoutTime,
                StartTime = _workingShift.StartTime,
                EndTime = _workingShift.EndTime,
                FormulaDefine = formula.Define
            };
        }

    }
}
