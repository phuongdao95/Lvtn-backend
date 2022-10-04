using AutoMapper;
using Models.DTO.Request;
using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using org.matheval;
using Services.Contracts;
using System.Security.Cryptography.Xml;

namespace Services.Services
{
    public class PayrollService : IPayrollService
    {
        private const string NAME = "name";
        private const string BASE_SALARY = "base_salary";
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


        private readonly IMapper _mapper;
        private readonly EmsContext _context;
        private readonly List<SalaryFormula> _allSalaryFormulas;
        private readonly List<SalaryVariable> _allSalaryVariables;

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

        public PayrollService(IMapper mapper, EmsContext context)
        {
            _mapper = mapper;
            _context = context;
            _allSalaryFormulas = _context.SalaryFormulas.ToList();
            _allSalaryVariables = _context.SalaryVariables.ToList();
        }

        //public void CreatePayroll(PayrollDTO payrollDTO)
        //{
        //    var payroll = _mapper.Map<Payroll>(payrollDTO);
        //    var users = _context.Users;


        //    foreach (var user in users)
        //    {
        //        var salaryFormulaName = user.Group?.Formula;
        //        var salaryFormula = _allSalaryFormulas.FirstOrDefault(formula => formula.Name.Equals(salaryFormulaName))
        //            ?.Name ?? $"{BASE_SALARY} - {TOTAL_DEDUCTION} + {TOTAL_ALLOWANCE} + {TOTAL_BONUS}";

        //        decimal total = 0;

        //        var expression = new Expression(salaryFormula);
        //        var variables = expression.getVariables();

        //        foreach (var variable in variables)
        //        {
        //            bindExpressionWithValueFromUser(user, expression, variable, payrollDTO.FromDate);
        //        }

        //        total = (decimal)expression.Eval();

        //        for (var date = payroll.FromDate; date < payroll.ToDate; date = date.AddDays(1))
        //        {
        //            var workingShiftTimekeepings = _context.WorkingShiftTimekeepings.Where(
        //                x => x.WorkingShiftEvent.StartTime.Day == date.Day &&
        //                    x.WorkingShiftEvent.StartTime.Month == date.Month &&
        //                    x.WorkingShiftEvent.StartTime.Year == date.Year);

        //            foreach (var timekeeping in workingShiftTimekeepings)
        //            {
        //                WorkingShiftEvent shift = timekeeping.WorkingShiftEvent;

        //                if (!shift.Users.Any(x => x.Id == timekeeping.EmployeeId))
        //                {
        //                    break;
        //                }
        //                var formula = timekeeping.WorkingShiftEvent.Formula;
        //                var exp = new Expression(formula);

        //                if (
        //                    timekeeping.DidCheckIn &&
        //                    timekeeping.DidCheckout)
        //                {
        //                    foreach (var variable in exp.getVariables())
        //                    {
        //                        bindExpressionWithValueFromTimekeeping(timekeeping, expression, variable);
        //                    }
        //                }
        //                else
        //                {
        //                    if (
        //                        (!timekeeping.DidCheckIn && !timekeeping.DidCheckout && exp.getVariables().Contains(DID_NOT_CHECKIN_CHECKOUT)) ||
        //                        (!timekeeping.DidCheckIn && timekeeping.DidCheckout && exp.getVariables().Contains(DID_NOT_CHECKIN)) ||
        //                        (!timekeeping.DidCheckout && timekeeping.DidCheckIn && exp.getVariables().Contains(DID_NOT_CHECKIN)))
        //                    {
        //                        foreach (var variable in exp.getVariables())
        //                        {
        //                            bindExpressionWithValueFromTimekeeping(timekeeping, expression, variable);
        //                        }
        //                    } else
        //                    {
        //                        exp = new Expression("0");
        //                    }
        //                }

        //                total += exp.Eval<Decimal>();
        //            }
        //        }


        //        payroll.PayslipList.Add(new Payslip
        //        {
        //            EmployeeId = user.Id,
        //            BaseSalary = user.BaseSalary,
        //            Description = payrollDTO.Description,
                    
        //        });
        //    }

        //    _context.Payrolls.Add(payroll);
        //    _context.SaveChanges();
        //}

        private void bindExpressionWithValueFromUser(User user, Expression expression, string variable, DateTime date)
        {
            if (AllSystemVariables.Contains(variable))
            {
                var (value, dataType) = getVariableValueFromUser(user, variable, date);
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

        private (object, VariableDataType) getVariableValueFromUser(User user, string key, DateTime date)
        {
            if (key == NAME)
            {
                return (user.Name, VariableDataType.Text);
            }
            else if (key == BASE_SALARY)
            {
                return (user.BaseSalary, VariableDataType.Number);
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
            else
            {
                throw new Exception("Key not available");
            }

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
                var formula = salaryDelta.Formula;
                var expression = new Expression(formula);
                var variables = expression.getVariables();

                foreach (var variable in variables)
                {
                    bindExpressionWithValueFromUser(user, expression, variable, date);
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

        public void UpdatePayroll(PayrollDTO payrollDTO)
        {
            var payroll = _context.Payrolls.Find(payrollDTO.Id);

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

        public void CreatePayroll(PayrollDTO payrollDTO)
        {
            throw new NotImplementedException();
        }
    }
}
