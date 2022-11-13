using Models.Enums;
using Models.Repositories.DataContext;
using org.matheval;

namespace Services.SalaryManagement.Calculators
{
    public class SalaryVariableBinder
    {
        private readonly EmsContext _context;
        public SalaryVariableBinder(EmsContext context)
        {
            _context = context;
        }

        public void BindExpression(Expression expression, string variable)
        {
            var salaryVariable = _context.SalaryVariables
                .Where(salaryVariable => salaryVariable.Name == variable)
                .Single();

            if (salaryVariable == null)
            {
                throw new Exception("Variable not found");
            }

            var valueExpression = new Expression(salaryVariable.Value);

            if (salaryVariable.DataType == VariableDataType.Text)
            {
                var value = valueExpression.Eval<string>();
                expression.Bind(variable, value);
            }
            else if (salaryVariable.DataType == VariableDataType.Decimal)
            {
                var value = valueExpression.Eval<decimal>();
                expression.Bind(variable, value);
            }
            else if (salaryVariable.DataType == VariableDataType.Integer)
            {
                var value = valueExpression.Eval<int>();
                expression.Bind(variable, value);
            }
            else if (salaryVariable.DataType == VariableDataType.Boolean)
            {
                var value = valueExpression.Eval<string>();
                expression.Bind(variable, value);
            }
            else
            {
                throw new Exception("Data type not found");
            }
        }
    }
}
