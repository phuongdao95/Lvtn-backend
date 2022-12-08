using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.DTO.Request;
using Models.Models;
using Models.Repositories.DataContext;

namespace Services.Services
{
    public class WorkingShiftTimekeepingHistoryService
    {
        private IMapper _mapper;
        private EmsContext _context;

        public WorkingShiftTimekeepingHistoryService(
            IMapper mapper,
            EmsContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Add(WorkingShiftTimekeepingHistoryDTO dto)
        {
            var shifts = _mapper.Map<WorkingShiftTimekeepingHistory>(dto);
            _context.Add(shifts);
            _context.SaveChanges();
        }
        public void Update(int id, WorkingShiftTimekeepingHistoryDTO dto)
        {
            var shift = _context.WorkingShiftTimekeepingHistory.Find(id);
            if (shift == null)
            {
                throw new Exception("not found working shift");
            }
            shift.DateTime = dto.DateTime;
            shift.IsCheckIn = dto.IsCheckIn;
            shift.TimekeepingId = dto.TimekeepingId;
            _context.Update(shift);
            _context.SaveChanges();
        }
        
    }
}
