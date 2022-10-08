using AutoMapper;
using Models.DTO.Request;
using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;
using Expression = org.matheval.Expression;

namespace Services.Services
{
    public class SalaryCalculatorService : ISalaryCalculatorService
    {
        private const string NAME = "name";
        private const string BASE_SALARY = "base_salary";
        private const string BASE_SALARY_PER_DAY = "base_salary_per_day";
        private const string GENDER = "gender";
        private const string CHECKIN_MINUTE_LATE = "checkin_minute_late";
        private const string CHECKIN_MINUTE_EARLY = "checkin_minute_early";
        private const string CHECKOUT_MINUTE_EARLY = "checkout_minute_early";
        private const string CHECKOUT_MINUTE_LATE = "checkout_minute_late";
        private const string DID_NOT_CHECKIN = "did_not_checkin";
        private const string DID_NOT_CHECKOUT = "did_not_checkout";
        private const string DID_NOT_CHECKIN_CHECKOUT = "did_not_timekeep";
        private const string TOTAL_WORKING_HOURS = "total_working_hours";
        private const string TOTAL_DEDUCTION = "total_deduction";
        private const string TOTAL_ALLOWANCE = "total_allowance";
        private const string TOTAL_BONUS = "total_bonus";
        private const string ACTUAL_SALARY = "actual_salary";
        private const string DEFAULT_SALARY_FORMULA = "base_salary - total_deduction + total_allowance + total_bonus";

        private readonly IMapper _mapper;
        private readonly EmsContext _context;
        private readonly List<SalaryFormula> _allSalaryFormulas;
        private readonly List<SalaryVariable> _allSalaryVariables;
        private readonly List<SalaryGroup> _allSalaryGroups;
        private readonly List<User> _allUsers;

        public static readonly List<string> AllSystemVariables = new List<string>
        {
            NAME,
            BASE_SALARY,
            GENDER,
            CHECKIN_MINUTE_LATE,
            CHECKIN_MINUTE_EARLY,
            CHECKOUT_MINUTE_LATE,
            CHECKOUT_MINUTE_EARLY,
            DID_NOT_CHECKIN,
            DID_NOT_CHECKOUT,
            DID_NOT_CHECKIN_CHECKOUT,
            TOTAL_ALLOWANCE,
            TOTAL_DEDUCTION,
            TOTAL_BONUS
        };

        public SalaryCalculatorService(IMapper mapper, EmsContext context)
        {
            _mapper = mapper;
            _context = context;
            _allSalaryFormulas = _context.SalaryFormulas.ToList();
            _allSalaryVariables = _context.SalaryVariables.ToList();
            _allUsers = _context.Users.ToList();
            _allSalaryGroups = _context.SalaryGroups.ToList();

            initilizeMapping();
        }

        private void initilizeMapping()
        {
            _allUsers.ForEach((user) =>
            {
                _context.Entry(user).Collection(u => u.SalaryDeltaList).Load();
                _context.Entry(user).Collection(u => u.Timekeepings).Load();

                foreach (var timekeeping in user.Timekeepings)
                {
                    _context.Entry(timekeeping).Reference(tk => tk.WorkingShiftEvent).Load();
                }
            });
        }

        public void CalculateSalaryAndWritePayslipsIntoDatabase(PayrollDTO payrollDTO)
        {
            var payroll = _mapper.Map<Payroll>(payrollDTO);
            payroll.FromDate = new DateTime(payrollDTO.Year, payrollDTO.Month, 1, 2, 0, 0);
            payroll.ToDate = new DateTime(payrollDTO.Year, payrollDTO.Month, 1, 23, 59, 59)
                .AddMonths(1).AddDays(-1);

            payroll.PayslipList = new List<Payslip>();

            foreach (var user in _allUsers)
            {
                var payslip = new Payslip()
                {
                    EmployeeId = user.Id
                };

                payslip.Timekeepings = new List<PayslipWorkingShiftTimekeeping>();

                calculateFromTimekeepingsAndWriteIntoPayslip(user, payroll, payslip);

                calculateFromActualSalaryDeductionAllowanceBonus(user, payroll, payslip);

                payroll.PayslipList.Add(payslip);

            }

            _context.Payrolls.Add(payroll);
            _context.SaveChanges();
        }


        private void calculateFromTimekeepingsAndWriteIntoPayslip(User user, Payroll payroll, Payslip payslip)
        {
            var numDaysOfMonth = payroll.ToDate.Subtract(payroll.FromDate).Days;

            var timekeepingOfMonths = user.Timekeepings.Where(
                tk => tk.WorkingShiftEvent.StartTime.Date > payroll.FromDate.Date &&
                tk.WorkingShiftEvent.EndTime.Date < payroll.ToDate.Date);

            foreach (var tk in timekeepingOfMonths)
            {
                var workingShift = tk.WorkingShiftEvent;

                var formulaName = workingShift.FormulaName;
                var formula = _context.SalaryFormulas.Where(f => f.Name == formulaName).SingleOrDefault();
                var expression = new Expression(formula.Define);
                var variables = expression.getVariables();

                var didCheckInAndCheckout = tk.DidCheckIn && tk.DidCheckout;
                var didCheckInButNotCheckOut = tk.DidCheckIn && !tk.DidCheckout;
                var didCheckOutButNotCheckIn = !tk.DidCheckIn && tk.DidCheckout;
                var didNotCheckInAndNotCheckout = !tk.DidCheckout && !tk.DidCheckout;

                if (didCheckInAndCheckout || 
                    (didCheckInButNotCheckOut && variables.Contains(DID_NOT_CHECKOUT)) ||
                    (didCheckOutButNotCheckIn && variables.Contains(DID_NOT_CHECKIN)) ||
                    (didNotCheckInAndNotCheckout && variables.Contains(DID_NOT_CHECKIN_CHECKOUT)))
                {
                    foreach (var variable in expression.getVariables())
                    {
                        bindExpressionWithValueFromTimekeeping(tk, expression, variable);
                    }
                }
                else
                {
                    expression = new Expression("0");
                }

                payslip.Timekeepings.Add(new PayslipWorkingShiftTimekeeping()
                {
                    Amount = expression.Eval<decimal>(),
                    CheckinTime = tk.CheckinTime,
                    CheckoutTime = tk.CheckoutTime,
                    DidCheckIn = tk.DidCheckIn,
                    DidCheckout = tk.DidCheckout,
                    StartTime = workingShift.StartTime,
                    EndTime = workingShift.EndTime,
                    Formula = formula.Define,
                });
            }

        }

        private void calculateFromActualSalaryDeductionAllowanceBonus(User user, Payroll payroll, Payslip payslip)
        {
            var salaryDeltas = user.SalaryDeltaList;
            if (salaryDeltas == null)
            {
                throw new Exception("salary deltas should not be null");
            }

            foreach (var sd in salaryDeltas)
            {
                var formula = findSalaryFormula(sd.FormulaName);
                var expression = new Expression(formula.Define);
                var variables = expression.getVariables();

                foreach (var variable in variables)
                {
                    bindExpressionWithValueFromUser(user, expression, variable, payroll.FromDate, payslip);
                }

                /** TODO: calculate salary delta and write into PayslipSalaryDeltaList */
                payslip.SalaryDeltas.Add(new PayslipSalaryDelta()
                {
                    Amount = expression.Eval<decimal>(),
                    FromMonth = sd.FromMonth,
                    ToMonth = sd.ToMonth,
                    Name = sd.Name,
                    SalaryDeltaType = sd.Type,
                }); 
            }
        }

        private SalaryFormula findSalaryFormula(string name)
        {
            var formula = _allSalaryFormulas.Where(p => p.Name == name).SingleOrDefault();
            if (formula == null)
            {
                throw new Exception("");
            }

            return formula;
        }

        private decimal calculateActualSalaryOfMonth(Payslip payslip)
        {
            var timeKeepings = payslip.Timekeepings;
            if (timeKeepings == null)
            {
                throw new Exception("Timekeepings should not be null here");
            }
            decimal total = 0;

            foreach (var tk in timeKeepings)
            {
                total += tk.Amount ?? 0;
            }

            return total;
        }

        private string findSalaryFormulaOfUserAndEnsureValidity(User user)
        {
            var groupId = user.GroupId;
            if (groupId == null)
            {
                return DEFAULT_SALARY_FORMULA;
            }

            var salaryGroup = _context.SalaryGroups.Where(sg => sg.GroupId == groupId).SingleOrDefault();

            if (salaryGroup == null)
            {
                throw new Exception("Cannot find salary");
            }

            if (salaryGroup.Formula == null)
            {
                throw new Exception("Cannot get the formula name of salary group");
            }

            var salaryFormula = _allSalaryFormulas.Where(p => p.Name == salaryGroup.Formula).SingleOrDefault();

            if (salaryFormula == null || salaryFormula.Define == null)
            {
                throw new Exception("Salary formula is null");
            }

            var formulaExpression = new Expression(salaryFormula.Define);
            var variables = formulaExpression.getVariables();

            foreach (var variable in variables)
            {
                if (_allSalaryFormulas.Any(v => v.Name == variable))
                {
                    throw new Exception("Cannot find the specified variable");
                }
            }

            return salaryFormula.Define;
        }

        private void bindExpressionWithValueFromUser(User user, Expression expression, string variable, DateTime date, Payslip? payslip)
        {
            if (AllSystemVariables.Contains(variable))
            {
                var (value, dataType) = getVariableValueFromUser(user, variable, date, payslip);
                if (dataType == VariableDataType.Number)
                {
                    var parsedResult = (decimal)value;
                    expression.Bind(variable, parsedResult);
                }
                else if (dataType == VariableDataType.Text)
                {
                    var parsedResult = (string)value;
                    expression.Bind(variable, parsedResult);
                }
                else if (dataType == VariableDataType.Boolean)
                {
                    var parsedResult = (bool)value;
                    expression.Bind(variable, parsedResult);
                }
                else if (dataType == VariableDataType.DateTime)
                {
                    var parsedResult = (DateTime)value;
                    expression.Bind(variable, parsedResult);
                }
            }
            else
            {
                var salaryVariable = _allSalaryVariables.Where(v => v.Name == variable).FirstOrDefault();
                var dataType = salaryVariable.DataType;
                var value = salaryVariable.Value;
                if (dataType == VariableDataType.Number)
                {
                    var parsedResult = new Expression(value).Eval<Decimal>();
                    expression.Bind(variable, parsedResult);
                }
                else if (dataType == VariableDataType.Text)
                {
                    var parsedResult = new Expression(value).Eval<string>();
                    expression.Bind(variable, parsedResult);
                }
                else if (dataType == VariableDataType.Boolean)
                {
                    var parsedResult = new Expression(value).Eval<bool>();
                    expression.Bind(variable, parsedResult);
                }
                else if (dataType == VariableDataType.DateTime)
                {
                    var parsedResult = new Expression(value).Eval<DateTime>();
                    expression.Bind(variable, parsedResult);
                }
            }
        }

        private void bindExpressionWithValueFromTimekeeping(WorkingShiftTimekeeping timekeeping, Expression expression, string variable)
        {
            if (AllSystemVariables.Contains(variable))
            {
                var (value, dataType) = getVariableValueFromTimeKeeping(timekeeping, variable);
                if (dataType == VariableDataType.Number)
                {
                    var parsedResult = (decimal)value;
                    expression.Bind(variable, parsedResult);
                }
                else if (dataType == VariableDataType.Text)
                {
                    var parsedResult = (string)value;
                    expression.Bind(variable, parsedResult);
                }
                else if (dataType == VariableDataType.Boolean)
                {
                    var parsedResult = (bool)value;
                    expression.Bind(variable, parsedResult);
                }
                else if (dataType == VariableDataType.DateTime)
                {
                    var parsedResult = (DateTime)value;
                    expression.Bind(variable, parsedResult);
                }
            }
            else
            {
                var salaryVariable = _allSalaryVariables.Where(v => v.Name == variable).FirstOrDefault();
                var dataType = salaryVariable.DataType;
                var value = salaryVariable.Value;
                if (dataType == VariableDataType.Number)
                {
                    var parsedResult = new Expression(value).Eval<Decimal>();
                    expression.Bind(variable, parsedResult);
                }
                else if (dataType == VariableDataType.Text)
                {
                    var parsedResult = new Expression(value).Eval<string>();
                    expression.Bind(variable, parsedResult);
                }
                else if (dataType == VariableDataType.Boolean)
                {
                    var parsedResult = new Expression(value).Eval<bool>();
                    expression.Bind(variable, parsedResult);
                }
                else if (dataType == VariableDataType.DateTime)
                {
                    var parsedResult = new Expression(value).Eval<DateTime>();
                    expression.Bind(variable, parsedResult);
                }
            }
        }

        private (object, VariableDataType) getVariableValueFromUser(User user, string key, DateTime date, Payslip? payslip)
        {
            if (key == NAME)
            {
                return (user.Name, VariableDataType.Text);
            }
            else if (key == BASE_SALARY)
            {
                return (user.BaseSalary, VariableDataType.Number);
            }
            else if (key == BASE_SALARY_PER_DAY)
            {
                return (calculateSalaryPerDay(user, date), VariableDataType.Number);
            }
            else if (key == GENDER)
            {
                return (user.Gender, VariableDataType.Boolean);
            }
            else if (key == TOTAL_DEDUCTION)
            {
                return (calculateTotalSalaryDeltasOfUser(user, false, SalaryDeltaType.Deduction, date), VariableDataType.Number);
            }
            else if (key == TOTAL_ALLOWANCE)
            {
                return (calculateTotalSalaryDeltasOfUser(user, false, SalaryDeltaType.Allowance, date), VariableDataType.Number);
            }
            else if (key == TOTAL_BONUS)
            {
                return (calculateTotalSalaryDeltasOfUser(user, false, SalaryDeltaType.Bonus, date), VariableDataType.Number);
            }
            else if (key == ACTUAL_SALARY && payslip != null)
            {
                return (calculateActualSalaryOfMonth(payslip), VariableDataType.Number);
            }
            else
            {
                throw new Exception("Key not available");
            }

        }

        private decimal calculateSalaryPerDay(User user, DateTime date)
        {
            var numDaysOfMonth = DateTime.DaysInMonth(date.Year, date.Month);

            return user.BaseSalary / numDaysOfMonth;
        }

        private decimal calculateTotalSalaryDeltasOfUser(User user, bool calculateAll, SalaryDeltaType type, DateTime date)
        {
            decimal result = 0;
            var salaryDeltaList = new List<SalaryDelta>();

            if (calculateAll)
            {
                salaryDeltaList = user.SalaryDeltaList;
            }
            else
            {
                salaryDeltaList = user.SalaryDeltaList.Where(x => x.Type == type).ToList();
            }

            salaryDeltaList = salaryDeltaList.Where(x => x.FromMonth <= date && x.ToMonth >= date).ToList();

            foreach (var salaryDelta in salaryDeltaList)
            {
                var formula = salaryDelta.FormulaName;
                var expression = new Expression(formula);
                var variables = expression.getVariables();

                foreach (var variable in variables)
                {
                    bindExpressionWithValueFromUser(user, expression, variable, date, null);
                }

                result += (decimal)expression.Eval();
            }

            return result;
        }


        private (object, VariableDataType) getVariableValueFromTimeKeeping(WorkingShiftTimekeeping timekeeping, string key)
        {
            var workingShiftEvent = timekeeping.WorkingShiftEvent;

            switch (key)
            {
                case CHECKIN_MINUTE_LATE:
                    return (-workingShiftEvent.StartTime.Subtract(timekeeping.CheckinTime.Value).Minutes, VariableDataType.Number);
                case CHECKOUT_MINUTE_EARLY:
                    return (workingShiftEvent.EndTime.Subtract(timekeeping.CheckoutTime.Value).Minutes, VariableDataType.Number);
                case TOTAL_WORKING_HOURS:
                    return (timekeeping.CheckoutTime.Value.Subtract(timekeeping.CheckinTime.Value).Minutes, VariableDataType.Number);
                default:
                    return (-workingShiftEvent.StartTime.Subtract(timekeeping.CheckinTime.Value).Minutes, VariableDataType.Number);
            }
        }
    }
}
