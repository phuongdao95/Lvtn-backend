using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Models.Models;
using Models.Repositories.DataContext;
using org.matheval;

namespace Services.SalaryManagement.Calculators
{
    public class SalaryDeltaCalculator
    {
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
            _salaryDelta = initSalaryDelta(salaryDelta);
            _userVariableBinder = new UserVariableBinder(context, user);
            _salaryVariableBinder = new SalaryVariableBinder(context);

        }

        private SalaryDelta initSalaryDelta(SalaryDelta salaryDelta)
        {
            _context.Entry(salaryDelta).Reference(sd => sd.Group).Load();

            return salaryDelta;
        }

        public PayslipSalaryDelta Calculate()
        {
            var formulaName = _salaryDelta.FormulaName;
            var formula = _context.SalaryFormulas
                .Where(f => f.Name == formulaName)
                .Single();

            if (formula == null)
            {
                return new PayslipSalaryDelta
                {
                    FormulaDefine = "!!invalid formula",
                    Amount = 0,
                    FromMonth = _salaryDelta.FromMonth,
                    ToMonth = _salaryDelta.ToMonth,
                    Name = _salaryDelta.Name,
                    SalaryDeltaType = _salaryDelta.Type,
                    GroupName = _salaryDelta.Group.Name,
                    GroupId = _salaryDelta.GroupId,
                    CalculatedSuccess = false,
                };
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
                FormulaDefine = formula.Define,
                Amount = expression.Eval<decimal>(),
                FromMonth = _salaryDelta.FromMonth,
                ToMonth = _salaryDelta.ToMonth,
                Name = _salaryDelta.Name,
                SalaryDeltaType = _salaryDelta.Type,
                GroupName = _salaryDelta.Group.Name,
                GroupId = _salaryDelta.GroupId
            };
        }
    }
}
