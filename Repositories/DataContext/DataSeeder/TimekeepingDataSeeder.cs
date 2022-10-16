using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.DataContext.DataSeeder
{
    public class TimekeepingDataSeeder : DataSeeder
    {

        private readonly List<WorkingShiftTimekeeping> _workingShiftTimekeepings;
        private readonly List<WorkingShiftEvent> _workingShiftEvents;
        private readonly List<User> _users;
        private readonly ModelBuilder _modelBuilder;
        public TimekeepingDataSeeder(ModelBuilder modelBuilder,
            List<User> users)
        {
            _modelBuilder = modelBuilder;   
            _users = users;

            // Order matters here
            _workingShiftEvents = seedWorkingShiftEvents();
            _workingShiftTimekeepings = seedWorkingShiftTimekeepings();
        }

        private List<WorkingShiftTimekeeping> seedWorkingShiftTimekeepings()
        {
            var result = new List<WorkingShiftTimekeeping>();
            var index = 0;

            foreach (var workingShiftEvent in _workingShiftEvents)
            {
                foreach (var user in _users)
                {
                    result.Add(new WorkingShiftTimekeeping
                    {
                        Id = ++index,
                        CheckinTime = workingShiftEvent.StartTime,
                        CheckoutTime = workingShiftEvent.EndTime,
                        DidCheckIn = true,
                        DidCheckout = true,
                        EmployeeId = user.Id,
                        WorkingShiftEventId = workingShiftEvent.Id,
                    });
                }
            }

            return result;
        }

        private List<WorkingShiftEvent> seedWorkingShiftEvents()
        {
            var result = new List<WorkingShiftEvent>();
            var index = 0;

            DateTime startDate = new DateTime(2022, 9, 1);
            DateTime endDate = new DateTime(2022, 10, 1);

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                {
                    continue;
                }

                result.Add(new WorkingShiftEvent
                {
                    Id = ++index,
                    Name = "Normal Working Day",
                    StartTime = date.AddHours(8),
                    EndTime = date.AddHours(17),
                    Description = "Normal Working Day",
                    FormulaName = "formula_1"
                });
            }

            return result;
        }


        public void SeedData()
        {
            _modelBuilder.Entity<WorkingShiftEvent>()
                .HasData(_workingShiftEvents);

            _modelBuilder.Entity<WorkingShiftTimekeeping>()
                .HasData(_workingShiftTimekeepings);

        }
    }
}
