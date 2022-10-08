using AutoMapper;
using Models.DTO.Request;
using Models.Models;
using Models.Repositories;
using Models.Repositories.DataContext;
using Services.Contracts;

namespace Services.Services
{
    public class WorkingShiftEventService : IWorkingShiftEventService
    {
        private readonly IWorkingShiftEventService _workShiftEventService;
        private IMapper _mapper;
        private EmsContext _context;

        public WorkingShiftEventService(IMapper mapper, EmsContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void Add(WorkingShiftEventDTO dto)
        {
            var shifts = _mapper.Map<WorkingShiftEvent>(dto);
            _context.Add(shifts);
            _context.SaveChanges();
        }

        public void Update(int id, WorkingShiftEventDTO dto)
        {
            var shift = _context.WorkingShiftEvents.Find(id);
            if (shift == null)
            {
                throw new Exception("not found working shift");
            }
            shift.Name = dto.Name;
            shift.StartTime = dto.StartTime;
            shift.EndTime = dto.EndTime;
            shift.Description = dto.Description;
            _context.WorkingShiftEvents.Update(shift);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var shift = _context.WorkingShiftEvents.Find(id);
            if (shift == null)
            {
                throw new Exception("not found id " + id.ToString());
            }
            _context.Entry(shift).Collection(s => s.Timekeepings).Load();
            _context.WorkingShiftEvents.Remove(shift);
            
            _context.SaveChanges();
        }

        public List<WorkingShiftEvent> GetAll(int offset, int limit, string query)
        {
            var shifts = _context.WorkingShiftEvents
                .Where((shift) => shift.Name.Contains(query))
                .ToList();

            return shifts;
        }

        public WorkingShiftEvent GetById(int id)
        {
            var shift = _context.WorkingShiftEvents.Find(id);
            if (shift == null)
            {
                throw new Exception("not found shift id " + id.ToString());
            }
            return shift;
        }

        public int GetCount()
        {
            return _context.WorkingShiftEvents.Count();
        }
    }
}
