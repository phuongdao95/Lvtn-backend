using AutoMapper;
using Models.DTO.Request;
using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Services.Services
{
    public class SalaryFormulaService : ISalaryFormulaService
    {
        private readonly IMapper _mapper;
        private readonly EmsContext _context;
        public SalaryFormulaService(IMapper mapper, EmsContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void DeleteFormula(int id)
        {
            var formula = _context.SalaryFormulas.Find(id);
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

        public List<SalaryFormula> GetFormulaList(int offset, int limit, string? query = "", string? queryType = "display_name")
        {
            return _context.SalaryFormulas
                .Where(formula => query.Contains(formula.DisplayName) ||
                    formula.DisplayName.Contains(query))
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        public List<SalaryVariable> GetVariableList(int offset, int limit, string? query = "", string? queryType = "display_name")
        {
            return _context.SalaryVariables
                .Where(formula => query.Contains(formula.DisplayName) ||
                    formula.DisplayName.Contains(query))
                .Skip(offset)
                .Take(limit)
                .ToList();
        }

        public int GetFormulaListCount(int offset, int limit, string? query = "", string? queryType = "display_name")
        {
            return GetFormulaList(offset, int.MaxValue, query, queryType).Count();
        }

        public int GetVariableListCount(int offset, int limit, string? query = "", string? queryType = "display_name")
        {
            return GetFormulaList(offset, int.MaxValue, query, queryType).Count();
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
            var formula = _context.SalaryFormulas.Find(id);
            if (formula == null)
            {
                throw new Exception("");
            }

            var mapped = _mapper.Map<SalaryFormula>(formulaDTO);
            mapped.Id = id;

            _context.SalaryFormulas.Update(mapped);
            _context.SaveChanges();

        }

        public void UpdateVariable(int id, SalaryVariableDTO variableDTO)
        {
            var variable = _context.SalaryVariables.Find(id);
            if (variable == null)
            {
                throw new Exception("variable not found");
            }

            var mapped = _mapper.Map<SalaryVariable>(variableDTO);
            mapped.DataType = GetVariableDataType(variableDTO.DataType);
            mapped.Id = id;

            _context.SalaryVariables.Update(mapped);
            _context.SaveChanges();
        }

        public void CreateFormula(SalaryFormulaDTO formulaDTO)
        {
            var formula = _mapper.Map<SalaryFormula>(formulaDTO);

            _context.SalaryFormulas.Add(formula);
            _context.SaveChanges();
        }

        public void CreateVariable(SalaryVariableDTO variableDTO)
        {
            var dataType = GetVariableDataType(variableDTO.DataType);
            var variable =  _mapper.Map<SalaryVariable>(variableDTO);

            variable.DataType = dataType;

            _context.SalaryVariables.Add(variable);
            _context.SaveChanges();
        }

        private VariableDataType GetVariableDataType(string dataType)
        {
            VariableDataType type;
            if (dataType == "number")
            {
                type = VariableDataType.Number;
            }
            else if (dataType == "text")
            {
                type = VariableDataType.Text;
            }
            else if (dataType == "boolean")
            {
                type = VariableDataType.Boolean;
            }
            else if (dataType == "datetime")
            {
                type = VariableDataType.DateTime;
            }
            else
            {
                throw new Exception("Not supported variable datatype");
            }

            return type;
        }
    }
}
