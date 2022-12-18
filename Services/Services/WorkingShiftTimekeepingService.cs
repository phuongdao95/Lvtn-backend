using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.DTO.Request;
using Models.Models;
using Models.Repositories.DataContext;

namespace Services.Services
{
    public class WorkingShiftTimekeepingService
    {
        private IMapper _mapper;
        private EmsContext _context;

        public WorkingShiftTimekeepingService(
            IMapper mapper, 
            EmsContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public void Add(WorkingShiftTimekeepingDTO dto)
        {
            var shifts = _mapper.Map<WorkingShiftTimekeeping>(dto);
            _context.Add(shifts);
            _context.SaveChanges();
        }
        public void Update(int id, WorkingShiftTimekeepingDTO dto)
        {
            var shift = _context.WorkingShiftTimekeepings.Find(id);
            if (shift == null)
            {
                throw new Exception("not found working shift");
            }
            shift.DidCheckIn = dto.DidCheckIn;
            shift.CheckinTime = dto.CheckinTime != null ? dto.CheckinTime : null;
            shift.DidCheckout = dto.DidCheckout;
            shift.CheckoutTime = dto.CheckoutTime != null ? dto.CheckoutTime : null;
            _context.WorkingShiftTimekeepings.Update(shift);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var shift = _context.WorkingShiftTimekeepings.Find(id);
            if (shift == null)
            {
                throw new Exception("not found id " + id.ToString());
            }
            _context.WorkingShiftTimekeepings.Remove(shift);
            _context.SaveChanges();
        }
        public List<WorkingShiftTimekeeping> GetAll(int userId, DateTime? currentDate, int eventId)
        {
            var shifts = _context.WorkingShiftTimekeepings
                .Where(s => s.EmployeeId.Equals(userId) 
                    //&& (currentDate.Value.Date.Equals(s.CheckinTime.Value.Date))
                    && s.WorkingShiftEventId.Equals(eventId)
                    )
                .OrderByDescending(s => s.CheckinTime)
                .ToList();
            if (shifts.Count == 0)
            {
                return null;
            }
            return shifts;
        }
        public WorkingShiftTimekeeping GetById(int id)
        {
            var shift = _context.WorkingShiftTimekeepings.Find(id);
            if (shift == null)
            {
                throw new Exception("not found shift id " + id.ToString());
            }
            return shift;
        }
        public int GetCount()
        {
            return _context.WorkingShiftTimekeepings.Count();
        }
        public List<WorkingShiftTimekeeping> GetAllUserId(int userId, DateTime? selectedDate)
        {
            var shifts = new List<WorkingShiftTimekeeping>();
            if (selectedDate.Value.Date.ToString().Equals("1/1/0001 12:00:00 AM"))
            {
                shifts = _context.WorkingShiftTimekeepings
                    .Where(s => s.EmployeeId == userId)
                    .ToList();
            } 
            else
            {
                shifts = _context.WorkingShiftTimekeepings
                    .Where(s => s.EmployeeId == userId
                        && s.CheckinTime.Value.Date.Equals(selectedDate.Value.Date))
                    .ToList();
            }
            foreach(var shift in shifts)
            {
                _context.Entry(shift).Reference(s => s.WorkingShiftEvent).Load();
            }
            // xu ly xem ngay do duoc tinh cong k?
            // TODO
            return shifts;
        }

        public List<WorkingShiftTimekeeping> GetWorkingShiftTimekeepingOfUser(int employeeId, DateTime startDate, DateTime endDate)
        {
            return _context.WorkingShiftTimekeepings
                .Where(timekeeping => timekeeping.EmployeeId == employeeId)
                .Where(timekeeping => timekeeping.WorkingShiftEvent.StartTime.Date >= startDate.Date &&
                    timekeeping.WorkingShiftEvent.EndTime.Date <= endDate.Date)
                .ToList();
        }


        public List<WorkingShiftTimekeeping> GetWorkingShiftTimekeepingOfUser(int employeeId, string query, string queryType)
        {
            if (!(queryType == "date" ||
                queryType == "all"))
            {
                throw new Exception("Invalid queryType");
            }

            if (queryType == "all")
            {
                return _context.WorkingShiftTimekeepings
                    .Include(timekeeping => timekeeping.TimekeepingHistories)
                    .Where(timekeeping => timekeeping.EmployeeId == employeeId)
                    .ToList();
            }

            var queryParts = query.Split("/");
            var day = int.Parse(queryParts[0]);
            var month = int.Parse(queryParts[1]);
            var year = int.Parse(queryParts[2]);

            var date = new DateTime(year, month, day);

            return _context.WorkingShiftTimekeepings
                    .Include(timekeeping => timekeeping.TimekeepingHistories)
                    .Include(timekeeping => timekeeping.WorkingShiftEvent)
                    .Where(timekeeping => timekeeping.EmployeeId == employeeId)
                    .Where(timekeeping => timekeeping.WorkingShiftEvent.StartTime.Date == date.Date)
                    .ToList();
        }

        public List<WorkingShiftTimekeeping> GetAllShiftsInAMonth(int userId, int chosenDay)
        {
            var currentTime = DateTime.Now;
            var date = new DateTime(currentTime.Year, currentTime.Month, chosenDay);


            var shifts = _context.WorkingShiftTimekeepings
                .Where(s => s.EmployeeId.Equals(userId)
                )
                .Where(s => s.WorkingShiftEvent.StartTime.Date.Equals(date.Date))
                .OrderByDescending(s => s.CheckinTime)
                .ToList();
            if (shifts.Count == 0)
            {
                return null;
            }
            foreach(var shift in shifts)
            {
                shift.Employee = null;
            }
            return shifts;
        }
    }
}
