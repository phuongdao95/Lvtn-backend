using Microsoft.EntityFrameworkCore;
using Models.Enums;
using Models.Models;

namespace Repositories.DataContext.DataSeeder
{
    public class SalaryManagementDataSeeder : DataSeeder
    {
        private static readonly Dictionary<string, SalaryVariable> _defaultSalaryDeltaVariableMap = 
            new Dictionary<string, SalaryVariable>
        {
            {
                "variable_1",
                new SalaryVariable
                {
                    Id = 1,
                    Name = "variable_1",
                    DisplayName = "Variable One",
                    Value = "200000",
                    DataType = VariableDataType.Number,
                    Description = "variable 1"
                }
            },
            {
                "variable_2",
                new SalaryVariable
                {
                    Id = 2,
                    Name = "variable_2",
                    DisplayName = "Variable Two",
                    Value = "170000",
                    DataType = VariableDataType.Number,
                    Description = "variable 2"
                }
            },
            {
                "variable_3",
                new SalaryVariable
                {
                    Id = 3,
                    Name = "variable_3",
                    DisplayName = "Variable Three",  
                    Value = "170000",
                    DataType = VariableDataType.Number,
                    Description = "variable 3"
                }
            },
            {
                "variable_4",
                new SalaryVariable
                {
                    Id = 4,
                    Name = "variable_4",
                    DisplayName = "Variable Four",
                    Value = "TRUE",
                    DataType = VariableDataType.Boolean
                }
            },
            {
                "variable_5",
                new SalaryVariable
                {
                    Id = 5,
                    Name = "variable_5",
                    DisplayName = "Variable Five",
                    Value = "FALSE",
                    DataType = VariableDataType.Boolean
                }
            }
        };

        private static readonly Dictionary<string, SalaryFormula> _defaultSalaryFormulaMap = new Dictionary<string, SalaryFormula>
        {
            {
                "formula_1",
                new SalaryFormula
                {
                    Id = 1,
                    Name = "formula_1",
                    Define = "200000",
                    Description = "formula_1",
                    DisplayName = "Formula One"
                }
            },

            {
                "formula_2",
                new SalaryFormula
                {
                    Id = 2,
                    Name = "formula_2",
                    Define = "200000 + variable_1",
                    Description = "formula_2",
                    DisplayName = "Formula Two"
                }
            },

            {
                "formula_3",
                new SalaryFormula
                {
                    Id = 3,
                    Name = "formula_3",
                    Define = "variable_1 + variable_2",
                    Description = "formula_3",
                    DisplayName = "Formula Three"
                }
            },

            {
                "formula_4",
                new SalaryFormula
                {
                    Id = 4,
                    Name = "formula_4",
                    Define = $"IF(variable_4, 400000, 200000)",
                    Description = "formula_4",
                    DisplayName = "Formula Three"
                }
            }
        };

        private static readonly Dictionary<string, SalaryDelta> _defaultSalaryDelta = new Dictionary<string, SalaryDelta>
        {
            {
                "salary_delta_1",
                new SalaryDelta
                {
                    Id = 1,
                    Name = "Salary Delta 1",
                    Description = "Salary Delta 2",
                    FormulaName = "formula_1"
                }
            },
            {
                "salary_delta_2",
                new SalaryDelta
                {
                    Id = 2,
                    Name = "Salary Delta 2",
                    Description = "Salary Delta 2",
                    FormulaName = "formula_2"
                }
            },
            {
                "salary_delta_3",
                new SalaryDelta
                {
                    Id = 3,
                    Name = "Salary Delta 3",
                    Description = "Salary Delta 3",
                    FormulaName = "formula_3"
                }
            }
        };

        private static readonly Dictionary<string, Payroll> _defaultPayrollMap = new Dictionary<string, Payroll>
        {
            {
                "payroll_1",
                new Payroll
                {
                    Id = 1,
                    Name = "Generated Payroll 1",
                    Description = "Generated payroll 1",
                    FromDate = new DateTime(2022, 9, 1),
                    ToDate = new DateTime(2022, 9, 30),
                }
            },
            {
                "payroll_2",
                new Payroll
                {
                    Id = 2,
                    Name = "Generated Payroll 2",
                    Description = "Generated payroll 2",
                    FromDate = new DateTime(2022, 8, 1),
                    ToDate = new DateTime(2022, 8, 30),
                }
            },
            {
                "payroll_3",
                new Payroll
                {
                    Id = 3,
                    Name = "Generated Payroll 2",
                    Description = "Generated payroll 2",
                    FromDate = new DateTime(2022, 8, 1),
                    ToDate = new DateTime(2022, 8, 30),
                }
            }
        };

        private readonly List<Payroll> _payrollList;
        private readonly List<SalaryDelta> _salaryDeltaList;
        private readonly List<SalaryFormula> _salaryFormulaList;
        private readonly List<SalaryVariable> _salaryVariableList;

        private ModelBuilder _modelBuilder;

        public SalaryManagementDataSeeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
            _payrollList = seedPayroll();
            _salaryDeltaList = seedSalaryDelta();
            _salaryFormulaList = seedSalaryFormula();
            _salaryVariableList = seedSalaryVariable();
        }

        private List<SalaryVariable> seedSalaryVariable()
        {
            var result = new List<SalaryVariable>();
            var index = _defaultSalaryDeltaVariableMap.Count() + 1;
            var count = 200;

            result.AddRange(_defaultSalaryDeltaVariableMap.Values);

            return result;
        }

        private List<SalaryDelta> seedSalaryDelta()
        {
            var result = new List<SalaryDelta>();
            int index = _defaultSalaryDelta.Count() + 1;
            var count = 200;

            result.AddRange(_defaultSalaryDelta.Values);

            return result;
        }

        private List<SalaryFormula> seedSalaryFormula()
        {
            var result = new List<SalaryFormula>();
            int index = _defaultSalaryFormulaMap.Count() + 1;
            int count = 200;

            result.AddRange(_defaultSalaryFormulaMap.Values);

            return result;
        }

        private List<Payroll> seedPayroll()
        {
            var result = new List<Payroll>();
            int index = 0;
            int countEach = 100;

            result.AddRange(_defaultPayrollMap.Values);

            return result;
        }

        public void SeedData()
        {
            _modelBuilder.Entity<SalaryDelta>()
                .HasData(_salaryDeltaList);

            _modelBuilder.Entity<SalaryFormula>()
                .HasData(_salaryFormulaList);

            _modelBuilder.Entity<SalaryVariable>()
                .HasData(_salaryVariableList);

            _modelBuilder.Entity<Payroll>()
                .HasData(_payrollList);
        }


    }
}
