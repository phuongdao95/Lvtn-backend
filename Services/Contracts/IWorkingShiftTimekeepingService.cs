using Models.DTO.Request;
using Models.Models;

namespace Services.Contracts
{
    public interface IWorkingShiftTimekeepingService
    {
        void Add(WorkingShiftTimekeepingDTO dto);
        void Update(int id, WorkingShiftTimekeepingDTO dto);
        void Delete(int id);
        List<WorkingShiftTimekeeping> GetAll(int userId, DateTime? currentDate, int eventId);
        WorkingShiftTimekeeping GetById(int id);
        int GetCount();
        List<WorkingShiftTimekeeping> GetAllUserId(int userId, DateTime? selectedDate);
    }
}
