using Models.DTO.Request;
using Models.Models;

namespace Services.Contracts
{
    public interface IWorkingShiftEventService
    {
        void Add(WorkingShiftEventDTO dto);
        void Update(int id, WorkingShiftEventDTO dto);
        void Delete(int id);
        List<WorkingShiftEvent> GetAll(int offset, int limit, string query);
        WorkingShiftEvent GetById(int id);
        int GetCount();
        List<WorkingShiftEvent> GetByUser(int userId, int offset, int limit, string query);
        void UpdateUserShift(int userId, List<int> shiftIds);
    }
}
