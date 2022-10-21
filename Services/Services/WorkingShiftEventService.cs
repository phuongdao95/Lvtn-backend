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
            shift.FormulaName = dto.Formula;
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
            foreach (var shift in shifts)
            {
                _context.Entry(shift).Collection(s => s.Users).Load();
            }
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

        public List<WorkingShiftEvent> GetByUser(int userId, int offset, int limit, string query)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                throw new Exception("not found user id " + userId.ToString());
            }
            var shifts = _context.WorkingShiftEvents.Where((shift) => shift.Name.Contains(query)).ToList();
            foreach (var shift in shifts)
            {
                _context.Entry(shift).Collection(s => s.Users).Load();
            }
            return shifts;
        }

        public void UpdateUserShift(int userId, List<int> shiftIds)
        {
            var user = _context.Users.Find(userId);
            var shifts = _context.WorkingShiftEvents.ToList();

            var lstUser = new List<User>();
            lstUser.Add(user);

            if (shifts == null)
            {
                throw new Exception("not found any shifts");
            }
            foreach (var shift in shifts)
            {
                var lst = new List<int>();
                // if users is null, add user to list users
                _context.Entry(shift).Collection(s => s.Users).Load();
                if (shift.Users == null && shiftIds.Contains(shift.Id))
                {
                    shift.Users = lstUser;
                    _context.WorkingShiftEvents.Update(shift);
                    _context.SaveChanges();
                    continue;
                }
                // if users not null, get all user id
                foreach (var shiftUser in shift.Users)
                {
                    lst.Add(shiftUser.Id);
                }
                // add user to list of user in shift has id in update
                if (shiftIds.Contains(shift.Id))
                {
                    if (!lst.Contains(userId))
                    {
                        shift.Users.Add(user);
                        _context.WorkingShiftEvents.Update(shift);
                        _context.SaveChanges();
                    }
                }
                // remove user in list of user in shift not has id in update
                else
                {
                    if (lst.Contains(userId))
                    {
                        shift.Users.Remove(user);
                        _context.WorkingShiftEvents.Update(shift);
                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}
