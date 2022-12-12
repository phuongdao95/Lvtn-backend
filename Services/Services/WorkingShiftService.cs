using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using System.Linq;

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
            var shift = _context.WorkingShifts.Find(id);
            if (shift == null)
            {
                throw new Exception("not found working shift");
            }
            shift.Name = dto.Name;
            shift.StartTime = dto.StartTime;
            shift.EndTime = dto.EndTime;
            shift.Description = dto.Description;
            shift.FormulaName = dto.FormulaName;
            _context.WorkingShifts.Update(shift);
            _context.SaveChanges();
        }

        public void RemoveWorkingShift(int id)
        {
            var shift = _context.WorkingShifts.Find(id);
            if (shift == null)
            {
                throw new Exception("not found id " + id.ToString());
            }
            _context.Entry(shift).Collection(s => s.Timekeepings).Load();
            _context.WorkingShifts.Remove(shift);

            _context.SaveChanges();
        }

        public List<WorkingShift> GetWorkingShifts(int offset, int limit, string query, string queryType = "month")
        {
            var queryParts = query.Split("/");
            var month = int.Parse(queryParts[0]);
            var year = int.Parse(queryParts[1]);

            var shifts = _context.WorkingShifts
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
            var shift = _context.WorkingShifts.Find(id);
            if (shift == null)
            {
                throw new Exception("not found shift id " + id.ToString());
            }
            return shift;
        }

        public int GetCount()
        {
            return _context.WorkingShifts.Count();
        }

        public void UpdateUserShift(int userId, List<int> shiftIds)
        {
            var user = _context.Users.Find(userId);
            var shifts = _context.WorkingShifts.ToList();

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
                    _context.WorkingShifts.Update(shift);
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
                        _context.WorkingShifts.Update(shift);
                        _context.SaveChanges();
                    }
                }
                // remove user in list of user in shift not has id in update
                else
                {
                    if (lst.Contains(userId))
                    {
                        shift.Users.Remove(user);
                        _context.WorkingShifts.Update(shift);
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

            var timekeeping = new WorkingShiftTimekeeping()
            {
                DidCheckIn = false,
                CheckinTime = null,
                DidCheckout = false,
                CheckoutTime = null,
                EmployeeId = user.Id,
                WorkingShiftEventId = shiftRegistration.WorkingShiftId,
            };

            _context.WorkingShiftTimekeepings.Add(timekeeping);

            _context.WorkingShiftRegistrationUsers.Add(new WorkingShiftRegistrationUser
            {
                UserId = registrationDTO.UserId,
                WorkingShiftRegistrationId = registrationDTO.WorkingShiftRegistrationId
            });

            _context.SaveChanges();
        }

        public void DeleteWorkingShiftRegistrationUser(int userId, int registrationId)
        {
            var registrationUser = _context.WorkingShiftRegistrationUsers
                .Where(p => p.UserId == userId &&
                    p.WorkingShiftRegistrationId == registrationId)
                .FirstOrDefault();

            if (registrationUser == null)
            {
                throw new Exception("Registration user is not found");
            }

            var registration = _context.WorkingShiftRegistrations
                .Include(p => p.WorkingShift)
                .Where(p => p.Id == registrationId)
                .FirstOrDefault();

            if (registration != null)
            {
                var timekeeping = _context.WorkingShiftTimekeepings
                    .Include(p => p.WorkingShiftEvent)
                    .Where(p => p.EmployeeId == userId && p.WorkingShiftEventId == registration.WorkingShiftId)
                    .FirstOrDefault();

                if (timekeeping != null)
                {
                    _context.WorkingShiftTimekeepings
                        .Remove(timekeeping);
                }
            }

            _context.WorkingShiftRegistrationUsers
                .Remove(registrationUser);

            _context.SaveChanges();
        }

        public void DeleteWorkingShiftRegistration(int id)
        {
            var shiftRegistrationUser = _context.WorkingShiftRegistrationUsers
                .Where(x => x.Id == id)
                .FirstOrDefault();

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

        public List<WorkingShiftRegistration> GetUnregistredWorkingShift(
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

            var registeredIds = _context.WorkingShiftRegistrationUsers
                .Where(p => p.UserId == userId)
                .Select(p => p.WorkingShiftRegistrationId)
                .ToList();

            var allWorkingShift = _context.WorkingShiftRegistrations
                .Include(registration => registration.WorkingShift)
                .Where(registration => registration.StartDate > new DateTime(year, month, 1, 0, 0, 0))
                .Where(registration => registration.EndDate < new DateTime(year, month,
                    DateTime.DaysInMonth(year, month), 23, 59, 59))
                .Where(p => !registeredIds.Contains(p.Id))
                .ToList();

            return allWorkingShift;
        }

        public List<WorkingShiftRegistrationUser> GetWorkingShiftRegistrationUsersOfUser(
            int userId,
            string query = "11/2022",
            string queryType = "registered_month")
        {
            if (queryType != "registered_month" &&
                queryType != "month" &&
                queryType != "date")
            {
                throw new Exception("Invalid query type");
            }

            var queryParts = query.Split("/");
            var month = int.Parse(queryParts[0]);
            var year = int.Parse(queryParts[1]);
            var day = 1;

            if (queryParts.Length > 2)
            {
                day = int.Parse(queryParts[0]);
                month = int.Parse(queryParts[1]);
                year = int.Parse(queryParts[2]);
            }

            var monthOfYear = new DateTime(year, month, day);


            if (queryType == "month" || queryType == "registered_month")
            {
                return _context.WorkingShiftRegistrationUsers
                    .Include(p => p.User)
                    .Include(p => p.WorkingShiftRegistration)
                        .ThenInclude(p => p.WorkingShift)
                    .Where(p => p.UserId == userId)
                    .Where(registrationUsers => registrationUsers.WorkingShiftRegistration.WorkingShift.StartTime.Month == monthOfYear.Month)
                    .Where(registrationUsers => registrationUsers.WorkingShiftRegistration.WorkingShift.StartTime.Year == monthOfYear.Year)
                    .ToList();
            }
            else
            {
                return _context.WorkingShiftRegistrationUsers
                    .Include(p => p.User)
                    .Include(p => p.WorkingShiftRegistration)
                        .ThenInclude(p => p.WorkingShift)
                    .Where(p => p.UserId == userId)
                    .Where(registrationUsers => registrationUsers.WorkingShiftRegistration.WorkingShift.StartTime.Day == monthOfYear.Day)
                    .Where(registrationUsers => registrationUsers.WorkingShiftRegistration.WorkingShift.StartTime.Month == monthOfYear.Month)
                    .Where(registrationUsers => registrationUsers.WorkingShiftRegistration.WorkingShift.StartTime.Year == monthOfYear.Year)
                    .ToList();
            }
        }

        public List<WorkingShiftDayConfig> GetWorkingShiftDayConfigs(string query, string queryType)
        {
            if (queryType != "month")
            {
                throw new Exception("Invalid query format");
            }

            var queryParts = query.Split("/");
            var month = int.Parse(queryParts[0]);
            var year = int.Parse(queryParts[1]);

            var date = new DateTime(year, month, 1);

            return _context.WorkingShiftDayConfigs
                .Where(config =>
                    config.Date.Month == date.Month &&
                    config.Date.Year == date.Year)
                .ToList();
        }

        public void CreateWorkingShiftDayConfig(WorkingShiftDayConfigDTO workingShiftDayConfigDTO)
        {
            var type = WorkingShiftDayConfigType.Holiday;

            if (workingShiftDayConfigDTO.Type == "holiday")
            {
                type = WorkingShiftDayConfigType.Holiday;
            }

            var normalizedDate = workingShiftDayConfigDTO.Date.Date;

            var workingShiftDayConfig = _mapper.Map<WorkingShiftDayConfig>(workingShiftDayConfigDTO);
            workingShiftDayConfig.Type = type;
            workingShiftDayConfig.Date = normalizedDate;

            _context.WorkingShiftDayConfigs.Add(workingShiftDayConfig);
            _context.SaveChanges();
        }

        public void UpdateWorkingShiftDayConfigs(int id, WorkingShiftDayConfigDTO workingShiftDayConfigDTO)
        {
            var workingShiftDayConfig = _mapper.Map<WorkingShiftDayConfig>(workingShiftDayConfigDTO);
            workingShiftDayConfig.Id = id;

            var type = WorkingShiftDayConfigType.Holiday;

            if (workingShiftDayConfigDTO.Type == "holiday")
            {
                type = WorkingShiftDayConfigType.Holiday;
            }

            workingShiftDayConfig.Type = type;

            _context.WorkingShiftDayConfigs.Update(workingShiftDayConfig);
            _context.SaveChanges();
        }

        public void DeleteWorkingShiftDayConfig(int id)
        {
            var workingShiftDayConfig = _context.WorkingShiftDayConfigs.Find(id);

            if (workingShiftDayConfig == null)
            {
                throw new Exception("Working shift day config not found");
            }

            _context.WorkingShiftDayConfigs.Remove(workingShiftDayConfig);
            _context.SaveChanges();
        }

        public void CreateWorkingShiftFixed(CreateFixedShiftDTO shiftDTO)
        {
            var group = _context.Groups.Where(gr => gr.Id == shiftDTO.GroupId)
             .Include(gr => gr.Users)
             .Single();


            var monthAndYear = shiftDTO.Month;
            var month = int.Parse(monthAndYear.Split("/")[0]);
            var year = int.Parse(monthAndYear.Split("/")[1]);

            var startDateOfMonth = new DateTime(year, month, 1, 0, 0, 1);
            var endDateOfMonth = new DateTime(year, month, DateTime.DaysInMonth(year, month), 23, 59, 59);

            List<WorkingShift> workingShifts = new List<WorkingShift>();

            for (var date = startDateOfMonth;
                date <= endDateOfMonth;
                date = date.AddDays(1))
            {

                if (!shiftDTO.WeekDayConfigs[(int)date.DayOfWeek])
                {
                    continue;
                }

                var startTime = date.AddHours(shiftDTO.StartTime.Hour);
                var endTime = date.AddHours(shiftDTO.EndTime.Hour);

                var workingShift = new WorkingShift
                {
                    Name = shiftDTO.Name,
                    WorkingShiftRegistration = new WorkingShiftRegistration
                    {
                        GroupId = shiftDTO.GroupId,
                    },
                    StartTime = startTime,
                    EndTime = endTime,
                    FormulaName = shiftDTO.FormulaName,
                    Type = WorkingShiftType.FIXED_SHIFT,
                    Users = group.Users,
                    Description = shiftDTO.Description,
                };

                workingShifts.Add(workingShift);
            }

            _context.WorkingShifts.AddRange(workingShifts);
            _context.SaveChanges();
        }

        public void CreateWorkingShiftOvertime(CreateOrUpdateOverTimeShiftDTO shiftDTO)
        {
            var group = _context.Groups.Where(gr => gr.Id == shiftDTO.GroupId)
                .Include(gr => gr.Users)
                .Single();

            var workingShift = new WorkingShift
            {
                Name = shiftDTO.Name,
                WorkingShiftRegistration = new WorkingShiftRegistration
                {
                    GroupId = shiftDTO.GroupId,
                    StartDate = shiftDTO.RegistrationStartDate,
                    EndDate = shiftDTO.RegistrationEndDate,
                },
                StartTime = shiftDTO.StartTime,
                EndTime = shiftDTO.EndTime,
                FormulaName = shiftDTO.FormulaName,
                Type = WorkingShiftType.OVERTIME_SHIFT,
                Users = group.Users,
                Description = shiftDTO.Description,
            };

            _context.WorkingShifts.Add(workingShift);
            _context.SaveChanges();
        }
    }
}
