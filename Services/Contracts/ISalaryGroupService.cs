using Models.DTO.Request;
using Models.Models;

namespace Services.Contracts
{
    public interface ISalaryGroupService
    {
        public void CreateSalaryGroup(SalaryGroupDTO groupDTO);
        public void UpdateSalaryGroup(int id, SalaryGroupDTO groupDTO);
        public void DeleteSalaryGroup(int id);
        public SalaryGroup GetSalaryGroupById(int id);
        public List<SalaryGroup> GetSalaryGroupList(int offset, int limit, string? query = "", string? queryType = "name");
        public int GetSalaryGroupCount(int offset, int limit, string? query = "", string? queryType = "name");
    }
}
