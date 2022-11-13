using Models.DTO.Request;
using Models.Models;

namespace Services.Contracts
{
    public interface IWorkingShiftEventService
    {
        void Add(WorkingShiftEventDTO dto);
        void Update(int id, WorkingShiftEventDTO dto);
        void Delete(int id);
        List<WorkingShift> GetAll(int offset, int limit, string query);
        WorkingShift GetById(int id);
        int GetCount();
        List<WorkingShift> GetByUser(int userId, int offset, int limit, string query);
        void UpdateUserShift(int userId, List<int> shiftIds);
    }
}
