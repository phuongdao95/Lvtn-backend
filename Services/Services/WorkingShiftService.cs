using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.Models;
using Models.Repositories.DataContext;

namespace Services.Services
{
    public class WorkingShiftService 
    {
        private IMapper _mapper;
        private EmsContext _context;

        public WorkingShiftService(IMapper mapper, EmsContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public void CreateWorkingShift(WorkingShiftEventDTO dto)
        {
            var shifts = _mapper.Map<WorkingShift>(dto);
            _context.Add(shifts);
            _context.SaveChanges();
        }

        public void UpdateWorkingShift(int id, WorkingShiftEventDTO dto)
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
            shift.FormulaName = dto.FormulaName;
            _context.WorkingShiftEvents.Update(shift);
            _context.SaveChanges();
        }

        public void RemoveWorkingShift(int id)
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

        public List<WorkingShift> GetWorkingShifts(int offset, int limit, string query, string queryType="month")
        {
            var queryParts = query.Split("/");
            var month = int.Parse(queryParts[0]);
            var year = int.Parse(queryParts[1]);

            var shifts = _context.WorkingShiftEvents
                .Where((shift) => shift.StartTime.Month == month 
                    && shift.StartTime.Year == year)
                .ToList();

            foreach (var shift in shifts)
            {
                _context.Entry(shift).Collection(s => s.Users).Load();
            }
            return shifts;
        }

        public WorkingShift GetWokringShiftById(int id)
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

        public List<WorkingShift> GetByUser(int userId, int offset, int limit, string query)
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

        public void CreateWorkingShiftRegistration(WorkingShiftRegistrationDTO registrationDTO)
        {
            var user = _context.Users.Find(registrationDTO.UserId);
            var shiftRegistration = _context.WorkingShiftRegistrations
                .Find(registrationDTO.WorkingShiftRegistrationId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (shiftRegistration == null)
            {
                throw new Exception("Shift registration not found");
            }

            _context.WorkingShiftRegistrationUsers.Add(new WorkingShiftRegistrationUser
            {
                UserId = registrationDTO.UserId,
                WorkingShiftRegistrationId = registrationDTO.WorkingShiftRegistrationId
            });

            _context.SaveChanges();
        }

        public void DeleteWorkingShiftRegistration(int id)
        {
            var shiftRegistrationUser = _context.WorkingShiftRegistrationUsers
                .FirstOrDefault(x => x.Id == id);

            if (shiftRegistrationUser == null)
            {
                throw new Exception("shiftRegistrationUser not found");
            }

            _context.WorkingShiftRegistrationUsers.Remove(shiftRegistrationUser);
            _context.SaveChanges();
        }

        public List<WorkingShiftRegistrationUser> GetWorkingShiftRegistrationUsers(
            string query = "11/2022",
            string queryType = "month")
        {
            if (queryType != "month")
            {
                throw new Exception("Invalid query type");
            }

            var queryParts = query.Split("/");
            var month = int.Parse(queryParts[0]);
            var year = int.Parse(queryParts[1]);

            return _context.WorkingShiftRegistrationUsers
                .Include(p => p.User)
                .Include(p => p.WorkingShiftRegistration)
                    .ThenInclude(p => p.WorkingShift)
                .Where(relation => relation
                        .WorkingShiftRegistration
                        .WorkingShift
                        .StartTime.Month == month &&
                       relation
                        .WorkingShiftRegistration
                        .WorkingShift
                        .StartTime.Year == year)
                .ToList();
        }

        public List<WorkingShiftRegistration> GetWorkingShiftRegistrations(
            string query = "11/2022",
            string queryType = "month")
        {
            if (queryType != "month")
            {
                throw new Exception("Invalid query type");
            }

            var queryParts = query.Split("/");
            var month = int.Parse(queryParts[0]);
            var year = int.Parse(queryParts[1]);

            return _context.WorkingShiftRegistrations
                .Include(registration => registration.WorkingShift)
                .Where(registration => registration.StartDate > new DateTime(year, month, 1, 0, 0, 0))
                .Where(registration => registration.EndDate < new DateTime(year, month, 
                    DateTime.DaysInMonth(year, month), 23, 59, 59))
                .ToList();
        
        }

        public List<WorkingShiftRegistrationUser> GetWorkingShiftRegistrationUsersOfUser(
            int userId,
            string query = "11/2022",
            string queryType = "month")
        {
            if (queryType != "month")
            {
                throw new Exception("Invalid query type");
            }

            var queryParts = query.Split("/");
            var month = int.Parse(queryParts[0]);
            var year = int.Parse(queryParts[1]);

            var monthOfYear = new DateTime(year, month, 1, 0, 0, 2);

            return _context.WorkingShiftRegistrationUsers
                .Include(p => p.User)
                .Include(p => p.WorkingShiftRegistration)
                    .ThenInclude(p => p.WorkingShift)
                .Where(p => p.UserId == userId)
                .Where(p => p.WorkingShiftRegistration.WorkingShift.StartTime.Month == monthOfYear.Month)
                .Where(p => p.WorkingShiftRegistration.WorkingShift.StartTime.Year == monthOfYear.Year)
                .ToList();
        }

        public List<User> GetRegisteredUserOfWorkingShift(int id)
        {
            var workingShift = _context.WorkingShiftEvents
                .Include(workingShift => workingShift.WorkingShiftRegistration)
                    .ThenInclude(registration => registration.RegisteredUsers)
                .FirstOrDefault(p => p.Id == id, null);

            if (workingShift == null || 
                workingShift.WorkingShiftRegistration == null ||
                workingShift.WorkingShiftRegistration.RegisteredUsers == null)
            {
                throw new Exception("Working shift not found");
            }

            return workingShift.WorkingShiftRegistration.RegisteredUsers;            
        }
    }
}
