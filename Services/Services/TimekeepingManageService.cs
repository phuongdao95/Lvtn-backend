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
    public class TimekeepingManageService
    {
        private IMapper _mapper;
        private EmsContext _context;

        public TimekeepingManageService(IMapper mapper, EmsContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<User> getUsers(int month)
        {
            var lstRes = _context.WorkingShiftRegistrationUsers
                .Where(res => res.WorkingShiftRegistration.WorkingShift.StartTime.Month  == month)
                .Include(res => res.User)
                .Include(res => res.WorkingShiftRegistration)
                .Include(res => res.WorkingShiftRegistration.WorkingShift)
                .ToList();
            Dictionary<int, int> dicUserTimeExpect = new Dictionary<int, int>();
            foreach (var res in lstRes)
            {
                int id = res.User.Id;
                TimeSpan time = res.WorkingShiftRegistration.WorkingShift.EndTime.Subtract(res.WorkingShiftRegistration.WorkingShift.StartTime);
                int numOfMinutes = (int)time.TotalMinutes;
                if (dicUserTimeExpect.ContainsKey(id))
                {
                    dicUserTimeExpect[id] += numOfMinutes;
                }
                else
                {
                    dicUserTimeExpect.Add(id, numOfMinutes);
                }
            }
            return null;
        }
    }
}
