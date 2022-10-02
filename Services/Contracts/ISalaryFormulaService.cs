using Models.DTO.Request;
using Models.Models;

namespace Services.Contracts
{
    public interface ISalaryFormulaService
    {
        public SalaryFormula GetFormulaById(int id);
        public List<SalaryFormula> GetFormulaList(int offset, int limit, string? query = "", string? queryType = "display_name");
        public int GetFormulaListCount(int offset, int limit, string? query = "", string? queryType = "display_name");
        public void DeleteFormula(int id);
        public void UpdateFormula(int id, SalaryFormulaDTO salaryDeltaFormulaDTO);
        public void CreateFormula(SalaryFormulaDTO formulaDTO);

        public SalaryVariable GetVariableById(int id);
        public List<SalaryVariable> GetVariableList(int offset, int limit, string? query = "", string? queryType = "display_name");
        public int GetVariableListCount(int offset, int limit, string? query = "", string? queryType = "display_name");
        public void UpdateVariable(int id, SalaryVariableDTO salaryDeltaVariableDTO);
        public void DeleteVariable(int id);
        public void CreateVariable(SalaryVariableDTO variableDTO);
    }
}
