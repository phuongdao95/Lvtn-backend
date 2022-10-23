using Microsoft.AspNetCore.Components;
using Models.Models;
using Models.Repositories.DataContext;
using org.matheval;

namespace Services.SalaryManagement.Calculators
{
    public class SalaryDeltaCalculator
    {
        private readonly User _user;
        private readonly SalaryDelta _salaryDelta;
        private readonly EmsContext _context;
        private readonly UserVariableBinder _userVariableBinder;
        private readonly SalaryVariableBinder _salaryVariableBinder;
        public SalaryDeltaCalculator(
            EmsContext context,
            User user,
            SalaryDelta salaryDelta)
        {
            _context = context;
            _user = user;
            _salaryDelta = salaryDelta;
            _userVariableBinder = new UserVariableBinder(context, user);
            _salaryVariableBinder = new SalaryVariableBinder(context);
        }

        public PayslipSalaryDelta Calculate()
        {
            var formulaName = _salaryDelta.FormulaName;
            var formula = _context.SalaryFormulas
                .Where(f => f.Name == formulaName)
                .Single();

            if (formula == null)
            {
                throw new Exception("formulaName not found");
            }

            var expression = new Expression(formula.Define);

            foreach (var variable in expression.getVariables())
            {
                if (_context.SalaryVariables.Any(v => v.Name == variable))
                {
                    var salaryVariable = _context.SalaryVariables
                        .Where(v => v.Name == variable)
                        .Single();

                    var salaryVariableValue = new Expression(salaryVariable.Value)
                        .Eval();

                    expression.Bind(variable, salaryVariableValue);
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

            return new PayslipSalaryDelta
            {
                Amount = expression.Eval<decimal>(),
                FromMonth = _salaryDelta.FromMonth,
                ToMonth = _salaryDelta.ToMonth,
                Name = _salaryDelta.Name,
                SalaryDeltaType = _salaryDelta.Type,
            };
        }
    }
}
