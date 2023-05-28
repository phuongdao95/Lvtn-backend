﻿using AutoMapper;
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

        public List<TimeManageResponseDTO> getUsers(int month, int year, int workCount)
        {
            var lstRes = _context.WorkingShiftRegistrationUsers
                .Where(res => res.WorkingShiftRegistration.WorkingShift.StartTime.Month  == month 
                               && res.WorkingShiftRegistration.WorkingShift.StartTime.Year == year)
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
            var lstCheckIn = _context.WorkingShiftTimekeepings
                .Where(res => res.CheckinTime.Value.Month == month
                            && res.CheckinTime.Value.Year == year)
                .Include(res => res.Employee)
                .ToList();
            Dictionary<int, int> dicUserTimeReal = new Dictionary<int, int>();
            foreach (var res in lstCheckIn)
            {
                int id = res.Employee.Id;
                int numOfMinutes = 0;
                if (res.CheckoutTime.HasValue && res.CheckinTime.HasValue)
                {
                    TimeSpan time = res.CheckoutTime.Value.Subtract(res.CheckinTime.Value);
                    numOfMinutes = (int)time.TotalMinutes;
                }
                if (dicUserTimeReal.ContainsKey(id))
                {
                    dicUserTimeReal[id] += numOfMinutes;
                }
                else
                {
                    dicUserTimeReal.Add(id, numOfMinutes);
                }
            }

            var lstUser = _context.Users
                .Include(res => res.Team)
                .Include(res => res.Role)
                .ToList();
            List<TimeManageResponseDTO> lstTimeManage = new List<TimeManageResponseDTO>();
            foreach (var res in lstUser)
            {                
                TimeManageResponseDTO newResponse = new TimeManageResponseDTO();
                newResponse.Id = res.Id;
                newResponse.Name = res.Name;
                newResponse.TeamName = res.Team?.Name;
                newResponse.Gender = res.Gender;
                newResponse.Role = res.Role?.Name;
                newResponse.TimeReal = dicUserTimeReal[res.Id];
                newResponse.TimeExpect = dicUserTimeExpect[res.Id];
                newResponse.TimeMiss = newResponse.TimeExpect - newResponse.TimeReal;
                if (
                    (workCount < 0 && newResponse.TimeMiss < 0) ||
                    (workCount > 0 && newResponse.TimeMiss > 0) ||
                    (workCount == 0 && newResponse.TimeMiss == 0)
                    )
                {
                    lstTimeManage.Add(newResponse);
                }
            }
            return lstTimeManage;
        }

        public Boolean isUserCheckFullTime(int day, int month, int year, int id)
        {
            var lstRes = _context.WorkingShiftRegistrationUsers
                .Where(res => res.WorkingShiftRegistration.WorkingShift.StartTime.Month == month
                               && res.WorkingShiftRegistration.WorkingShift.StartTime.Year == year
                               && res.WorkingShiftRegistration.WorkingShift.StartTime.Day == day
                               && res.UserId == id)
                .Include(res => res.User)
                .Include(res => res.WorkingShiftRegistration)
                .Include(res => res.WorkingShiftRegistration.WorkingShift)
                .ToList();
            Dictionary<int, int> dicUserTimeExpect = new Dictionary<int, int>();
            foreach (var res in lstRes)
            {
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


            var lstCheckIn = _context.WorkingShiftTimekeepings
                .Where(res => res.CheckinTime.Value.Month == month
                            && res.CheckinTime.Value.Year == year
                            && res.CheckinTime.Value.Day == day
                            && res.EmployeeId == id)
                .Include(res => res.Employee)
                .ToList();
            Dictionary<int, int> dicUserTimeReal = new Dictionary<int, int>();
            foreach (var res in lstCheckIn)
            {
                int numOfMinutes = 0;
                if (res.CheckoutTime.HasValue && res.CheckinTime.HasValue)
                {
                    TimeSpan time = res.CheckoutTime.Value.Subtract(res.CheckinTime.Value);
                    numOfMinutes = (int)time.TotalMinutes;
                }
                if (dicUserTimeReal.ContainsKey(id))
                {
                    dicUserTimeReal[id] += numOfMinutes;
                }
                else
                {
                    dicUserTimeReal.Add(id, numOfMinutes);
                }
            }
            if ((!dicUserTimeExpect.ContainsKey(id) || dicUserTimeExpect[id] == 0)
                && (dicUserTimeReal.ContainsKey(id) || dicUserTimeReal[id] == 0))
            {
                return true;
            }
            return dicUserTimeExpect[id] <= dicUserTimeReal[id];
        }
    }
}