using Models.Models;
using Models.Repositories.DataContext;
using org.matheval;

namespace Services.SalaryManagement.Calculators
{
    public class SalaryDeltaVariableBinder
    {

        private static List<SalarySystemVariable> _systemVariables =
            new List<SalarySystemVariable>() { };

        private User _user;
        private EmsContext _context;
        private SalaryDelta _salaryDelta;
        private UserVariableBinder _userVariableBinder;
        private SalaryVariableBinder _salaryVariableBinder;
        public SalaryDeltaVariableBinder(
            EmsContext context,
            User user,
            SalaryDelta salaryDelta
            )
        {
            _user = user;
            _context = context;
            _salaryDelta = salaryDelta;
            _userVariableBinder = new UserVariableBinder(context, user);
            _salaryVariableBinder = new SalaryVariableBinder(context);
        }

        public void BindExpression(Expression expression, string variable)
        {
            if (!ContainsVariable(variable))
            {
                throw new Exception("variable not found");
            }
        }

        public bool ContainsVariable(string variable)
        {
            return _systemVariables.Any(v => v.Name == variable);
        }

        public static List<SalarySystemVariable> GetSystemVariables()
        {
            return _systemVariables.Concat(
                UserVariableBinder.GetSystemVariables())
                .ToList();
        }
    }
}
