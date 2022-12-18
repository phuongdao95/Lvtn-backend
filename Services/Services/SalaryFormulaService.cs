using AutoMapper;
using Models.DTO.Request;
using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using org.matheval;
using Services.SalaryManagement.Calculators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace Services.Services
{
    public class SalaryFormulaService
    {
        private readonly IMapper _mapper;
        private readonly EmsContext _context;
        public SalaryFormulaService(IMapper mapper, 
            EmsContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void DeleteFormula(int id)
        {
            var formula = _context.SalaryFormulas.Find(id);
            if (formula == null)
            {
                throw new Exception("Formula not found");
            }

            _context.SalaryFormulas.Remove(formula);
            _context.SaveChanges();
        }

        public void DeleteVariable(int id)
        {
            var variable = _context.SalaryVariables.Find(id);
            if (variable == null)
            {
                throw new Exception("Variable not found");
            }

            _context.SalaryVariables.Remove(variable);
            _context.SaveChanges();
        }

        public SalaryFormula GetFormulaById(int id)
        {
            var formula = _context.SalaryFormulas.Find(id);
            if (formula == null)
            {
                throw new Exception("Not found exception");
            }

            return formula;
        }

        public List<SalaryFormula> GetFormulaList(string query = "", string queryType = "area")
        {
            if (queryType != "area")
            {
                throw new Exception("Invalid query");
            }

            FormulaArea area = FormulaArea.SalaryDelta;
            area = GetAreaFromText(query);

            return _context.SalaryFormulas
                .Where(formula => formula.Area == area)
                .ToList();
        }

        public FormulaArea GetAreaFromText(string text)
        {
            switch (text)
            {
                case "kpi":
                    return FormulaArea.KPI;
                case "salaryconfig":
                    return FormulaArea.SalaryConfig;
                case "salarydelta":
                    return FormulaArea.SalaryDelta;
                case "timekeeping":
                    return FormulaArea.Timekeeping;
                default:
                    return FormulaArea.SalaryConfig;
            }
        }

        public List<SalaryVariable> GetVariableList(string? query = "", string? queryType = "area")
        {
            if (queryType != "area")
            {
                throw new Exception("Invalid query type");
            }

            FormulaArea area = FormulaArea.SalaryDelta;
            area = GetAreaFromText(query);

            return _context.SalaryVariables
                .Where(variable => variable.Area == area)
                .ToList();
        }

        public int GetFormulaListCount(string? query = "", string? queryType = "area")
        {
            return GetFormulaList(query, queryType).Count();
        }

        public int GetVariableListCount(string? query = "", string? queryType = "area")
        {
            return GetFormulaList(query, queryType).Count();
        }

        public SalaryVariable GetVariableById(int id)
        {
            var variable = _context.SalaryVariables.Find(id);
            if (variable == null)
            {
                throw new Exception("Formula Variable is null");
            }

            return variable;
        }

        public void UpdateFormula(int id, SalaryFormulaDTO formulaDTO)
        {
            var mapped = _mapper.Map<SalaryFormula>(formulaDTO);
            mapped.Id = id;
            mapped.Area = GetAreaFromText(formulaDTO.FormulaArea);

            _context.SalaryFormulas.Update(mapped);
            _context.SaveChanges();
        }

        private void ensureVariableValid(SalaryVariable variable)
        {
            try
            {
                var expression = new Expression(variable.Value);

                if (variable.DataType == VariableDataType.Text)
                {
                    expression.Eval<string>();   
                }
                else if (variable.DataType == VariableDataType.Decimal)
                {
                    expression.Eval<decimal>();
                }
                else if (variable.DataType == VariableDataType.Integer)
                {
                    expression.Eval<int>();
                }
                else if (variable.DataType == VariableDataType.Boolean)
                {
                    expression.Eval<bool>();
                }
            }
            catch (Exception)
            {
                throw new Exception("Variable is invalid");
            }
        }

        public void UpdateVariable(int id, SalaryVariableDTO variableDTO)
        {
            var variable = _context.SalaryVariables.Find(id);
            if (variable == null)
            {
                throw new Exception("Variable not found");
            }

            variable.DisplayName = variableDTO.DisplayName;
            variable.Value = variableDTO.Value;
            variable.Description = variableDTO.Description;
            
            ensureVariableValid(variable);

            _context.SalaryVariables.Update(variable);
            _context.SaveChanges();
        }

        public void CreateFormula(SalaryFormulaDTO formulaDTO)
        {
            var formula = _mapper.Map<SalaryFormula>(formulaDTO);
            formula.Area = GetAreaFromText(formulaDTO.FormulaArea);

            _context.SalaryFormulas.Add(formula);
            _context.SaveChanges();
        }

        public void CreateVariable(SalaryVariableDTO variableDTO)
        {
            var dataType = GetVariableDataType(variableDTO.DataType);
            var variable =  _mapper.Map<SalaryVariable>(variableDTO);

            variable.DataType = dataType;
            variable.Area = GetAreaFromText(variableDTO.FormulaArea);

            ensureVariableValid(variable);

            _context.SalaryVariables.Add(variable);
            _context.SaveChanges();
        }


        private VariableDataType GetVariableDataType(string dataType)
        {
            VariableDataType type;
            if (dataType == "Decimal")
            {
                type = VariableDataType.Decimal;
            }
            else if (dataType == "Text")
            {
                type = VariableDataType.Text;
            }
            else if (dataType == "Boolean")
            {
                type = VariableDataType.Boolean;
            }
            else if (dataType == "Integer")
            {
                type = VariableDataType.Integer;
            }
            else
            {
                throw new Exception("Not supported variable datatype");
            }

            return type;
        }

        private SalarySystemVariableKind mapFromFormulaArea(FormulaArea area)
        {
            var salarySystemVariableKind = new SalarySystemVariableKind();
            if (area == FormulaArea.SalaryDelta)
            {
                salarySystemVariableKind = SalarySystemVariableKind.SalaryDelta;
            }
            else if (area == FormulaArea.Timekeeping)
            {
                salarySystemVariableKind = SalarySystemVariableKind.Timekeeping;
            }
            else 
            {
                salarySystemVariableKind = SalarySystemVariableKind.SalaryGroup;
            }

            return salarySystemVariableKind;
        }

        public bool CheckIfFormulaExistsByNameAndArea(string name, FormulaArea area)
        {
            var formula = _context.SalaryFormulas
                .Where((formula) => formula.Name == name)
                .Where((formula) => formula.Area == area)
                .ToList();

            var salarySystemVariableKind = mapFromFormulaArea(area);
            var allFormulas = _context.SalaryFormulas.Where(variable => variable.Area == area);

            if (allFormulas.Any((formula) => formula.Name == name))
            {
                return true;
            }

            return false;
        }

        public bool CheckIfVariableExistsByNameAndArea(string name, FormulaArea area)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            var variables = _context.SalaryVariables
                .Where((formula) => formula.Name == name)
                .Where((formula) => formula.Area == area)
                .ToList();

            var salarySystemVariableKind = mapFromFormulaArea(area);
            var systemVariables = GetSystemVariables(salarySystemVariableKind);
            var allVariables = _context.SalaryVariables.Where(variable => variable.Area == area);

            if (systemVariables.Any((formula) => formula.Name == name) ||
                allVariables.Any((formula) => formula.Name == name))
            {
                return true;
            }

            return false;
        }

        public bool CheckIfVariableExistsInAnyFormula(string variableName)
        {
            var allFormulas = _context.SalaryFormulas.ToList();

            foreach (var formula in allFormulas)
            {
                var define = formula.Define;
                var expression = new Expression(define);
               
                if (expression.getVariables().Any(name => name == variableName))
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckIfVariableDefineValid(string variableDefine, VariableDataType dataType)
        {
            if (variableDefine == "")
            {
                return false;
            }

            var expression = new Expression(variableDefine);
            var variables = expression.getVariables();
            if (variables.Count() > 0 || expression.GetError().Any())
            {
                return false;
            }

            return validateVariableWithDatatype(variableDefine, dataType);
        }

        private bool validateVariableWithDatatype(string expression, VariableDataType dataType)
        {
            try
            {
                if (dataType == VariableDataType.Text)
                {
                    var res = new Expression(expression).Eval<string>();
                }
                else if (dataType == VariableDataType.Integer)
                {
                    var res = new Expression(expression).Eval<int>();
                }
                else if (dataType == VariableDataType.Boolean)
                {
                    var res = new Expression(expression).Eval<bool>();
                }
                else if (dataType == VariableDataType.Decimal)
                {
                    var res = new Expression(expression).Eval<decimal>();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool CheckIfFormulaDefineIsValid(string formulaDefine, FormulaArea area)
        {
            if (formulaDefine == "")
            {
                return false;
            }

            var expression = new Expression(formulaDefine);

            if (expression.GetError().Any())
            {
                return false;
            }

            var variables = expression.getVariables();
            var salarySystemVariableKind = mapFromFormulaArea(area);
            var systemVariables = GetSystemVariables(salarySystemVariableKind);
            var allVariables = _context.SalaryVariables.Where(variable => variable.Area == area);
            foreach (var variable in variables)
            {
                if (!allVariables.Any((v) => v.Name == variable) &&
                    !systemVariables.Any((v) => v.Name == variable))
                {
                    return false;
                }
            }

            return validateFormulaDataTypeToBeDecimal(formulaDefine, area);
        }

        private bool validateFormulaDataTypeToBeDecimal(string formulaDefine, FormulaArea area)
        {
            var expression = new Expression(formulaDefine);

            var variables = expression.getVariables();
            var salarySystemVariableKind = mapFromFormulaArea(area);
            var allSystemVariables = GetSystemVariables(salarySystemVariableKind);
            var allVariables = _context.SalaryVariables.Where(variable => variable.Area == area);
            try
            {
                foreach (var variable in variables)
                {
                    if (allVariables.Any((v) => v.Name == variable))
                    {
                        var variableObj = allVariables.First((v) => v.Name == variable);
                        bindDummyDataForValidation(expression, variable, variableObj.DataType);
                    }
                    else if (!allSystemVariables.Any((v) => v.Name == variable))
                    {
                        var variableObj = allVariables.First((v) => v.Name == variable);
                        bindDummyDataForValidation(expression, variable, variableObj.DataType);
                    }
                }

                decimal result = expression.Eval<decimal>();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        private void bindDummyDataForValidation(Expression expression, string variableName, VariableDataType dataType)
        {
            if (dataType == VariableDataType.Integer)
            {
                expression.Bind(variableName, 0);
            }
            else if (dataType == VariableDataType.Decimal)
            {
                expression.Bind(variableName, decimal.Zero);
            }
            else if (dataType == VariableDataType.Boolean)
            {
                expression.Bind(variableName, true);
            }
            else if (dataType == VariableDataType.Text)
            {
                expression.Bind(variableName, "");
            }
        }


        public List<SalarySystemVariable> GetSystemVariables(SalarySystemVariableKind kind)
        {
            var result = new List<SalarySystemVariable>();
            switch (kind)
            {
                case SalarySystemVariableKind.SalaryDelta:
                    result = SalaryDeltaVariableBinder.GetSystemVariables();
                    break;
                case SalarySystemVariableKind.SalaryGroup:
                    result = TotalSalaryVariableBinder.GetSystemVariables();
                    break;
                case SalarySystemVariableKind.Timekeeping:
                    result = TimekeepingVariableBinder.GetSystemVariables();
                    break;
                case SalarySystemVariableKind.KPI:
                    result = KPIVariableBinder.GetSystemVariables();
                    break;
                default:
                    throw new Exception("VariableKind not found");
            }

            int index = 0;

            result.ForEach(systemVariable =>
            {
                systemVariable.Id = ++index;
                systemVariable.IsUsedFor = kind;
            });

            return result;
        }
    }
}
