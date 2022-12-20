using Microsoft.AspNetCore.Components.Web;
using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using org.matheval;

namespace Services.SalaryManagement.Calculators
{
    public class UserVariableBinder
    {
        private static List<SalarySystemVariable> _systemVariables = new List<SalarySystemVariable>
        {
            new SalarySystemVariable
            {
                Name="gender",
                DisplayName= "Giới tính",
                Description = "Giới tính của nhân viên, trả về chuỗi male nếu là nam, female nếu là nữ",
                DataType = VariableDataType.Text,
            },

            new SalarySystemVariable
            {
                Name="age",
                DisplayName="Tuối",
                Description = "Số tuổi của nhân viên",
                DataType = VariableDataType.Integer,
            },

            new SalarySystemVariable
            {
                Name="base_salary",
                DisplayName="Lương cơ bản",
                Description="Lương cơ bản của nhân viên",
                DataType = VariableDataType.Decimal,
            },
        };

        private EmsContext _context;
        private User _user;
        public UserVariableBinder(EmsContext context, User user)
        {
            _context = context;
            _user = user;
        }

        public bool ContainsVariable(string name)
        {
            return _systemVariables.Any(v => v.Name == name);
        }

        public void BindExpression(Expression expression, string name)
        {
            if (!ContainsVariable(name))
            {
                throw new Exception("System Variable Not Found");
            }

            switch (name)
            {
                case "gender":
                    expression.Bind(name, GetGender());
                    break;
                case "age":
                    expression.Bind(name, GetAge());
                    break;
                case "base_salary":
                    expression.Bind(name, GetBaseSalary());
                    break;
                default:
                    throw new Exception("Cannot find variable");
            }

        }

        public string GetGender()
        {
            return _user.Gender ?? "";
        }

        public decimal GetBaseSalary()
        {
            return _user.BaseSalary;
        }

        public int GetAge()
        {
            return DateTime.Now.Year - _user.Birthday.Value.Year;
        }

        public static List<SalarySystemVariable> GetSystemVariables()
        {
            return _systemVariables;
        }

    }
}
