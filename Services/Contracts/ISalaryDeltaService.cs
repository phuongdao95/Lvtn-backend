using Models.DTO.Request;
using Models.Enums;
using Models.Models;

namespace Services.Contracts
{
    public interface ISalaryDeltaService
    {
        public void CreateSalaryDelta(SalaryDeltaDTO salaryDeltaDTO);
        public void UpdateSalaryDelta(int id, SalaryDeltaDTO salaryDeltaDTO);
        public void DeleteSalaryDelta(int id);
        public SalaryDelta GetSalaryDeltaById(int id);
        public List<SalaryDelta> GetSalaryDeltaList(
            int offset, 
            int limit, 
            string? query, 
            string? queryType);

        public int GetSalaryDeltaListCount(
            string? query = "", 
            string? queryType = "name"
          );
    }
}
