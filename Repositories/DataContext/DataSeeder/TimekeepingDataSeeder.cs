using Microsoft.EntityFrameworkCore;
using Models.Enums;
using Models.Models;

namespace Repositories.DataContext.DataSeeder
{
    public class TimekeepingDataSeeder : DataSeeder
    {

        private readonly List<WorkingShiftTimekeeping> _workingShiftTimekeepings;
        private readonly List<WorkingShift> _workingShiftEvents;
        private readonly List<User> _users;
        private readonly List<WorkingShiftRegistration> _workingShiftRegistrations;
        private readonly ModelBuilder _modelBuilder;
        public TimekeepingDataSeeder(ModelBuilder modelBuilder,
            List<User> users)
        {
            _modelBuilder = modelBuilder;   
            _users = users;

            // Order matters here
            _workingShiftEvents = seedWorkingShiftEvents();
            _workingShiftTimekeepings = seedWorkingShiftTimekeepings();
            _workingShiftRegistrations = seedWorkingShiftRegistrations();
        }

        private List<WorkingShiftRegistration> seedWorkingShiftRegistrations()
        {
            var result = new List<WorkingShiftRegistration>();
            var index = 0;

            DateTime startDate = new DateTime(2022, 9, 1);
            DateTime endDate = new DateTime(2023, 1, 1);

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                {
                    continue;
                }

                result.Add(new WorkingShiftRegistration
                {
                    Id = ++index,
                    GroupId = 4,
                    WorkingShiftId = index,
                    StartDate = date.AddHours(8).AddDays(-30),
                    EndDate = date.AddHours(17).AddDays(-12),
                });
            }

            return result;
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

        private List<WorkingShift> seedWorkingShiftEvents()
        {
            var result = new List<WorkingShift>();
            var index = 0;

            DateTime startDate = new DateTime(2022, 9, 1);
            DateTime endDate = new DateTime(2023, 1, 1);

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
                {
                    continue;
                }

                result.Add(new WorkingShift
                {
                    Id = ++index,
                    Name = "Normal Working Day",
                    StartTime = date.AddHours(8),
                    EndTime = date.AddHours(17),
                    Type = WorkingShiftType.FIXED_SHIFT,
                    Description = "Normal Working Day",
                    FormulaName = "salary_formula_per_day"
                });
            }

            return result;
        }


        public void SeedData()
        {
            _modelBuilder.Entity<WorkingShift>()
                .HasData(_workingShiftEvents);

            _modelBuilder.Entity<WorkingShiftTimekeeping>()
                .HasData(_workingShiftTimekeepings);

            _modelBuilder.Entity<WorkingShiftRegistration>()
                .HasData(_workingShiftRegistrations);
        }
    }
}
