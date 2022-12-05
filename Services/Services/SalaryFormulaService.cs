﻿using AutoMapper;
using Models.DTO.Request;
using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using org.matheval;
using Services.SalaryManagement.Calculators;
using System.Runtime.InteropServices;

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
            var mapped = _mapper.Map<SalaryVariable>(variableDTO);
            mapped.Id = id;
            mapped.DataType = GetVariableDataType(variableDTO.DataType);
            mapped.Area = GetAreaFromText(variableDTO.FormulaArea);

            ensureVariableValid(mapped);

            _context.SalaryVariables.Update(mapped);
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
