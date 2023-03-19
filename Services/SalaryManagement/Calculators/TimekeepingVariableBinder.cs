using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using org.matheval;
using org.matheval.Common;

namespace Services.SalaryManagement.Calculators
{
    public class TimekeepingVariableBinder
    {
        private static List<SalarySystemVariable> _systemVariables =
            new List<SalarySystemVariable>()
        {
            new SalarySystemVariable
            {
                Name = "checkin_minute_late",
                DisplayName = "Thời gian đi trễ",
                Description = "Khoảng thời gian trễ khi checkin trong một ca làm việc của nhân viên",
                DataType = VariableDataType.Integer,
            },

            new SalarySystemVariable
            {
                Name = "checkout_minute_early",
                DisplayName = "Thời gian về sớm",
                Description = "Khoảng thời gian sớm khi checkout trong một ca làm việc của nhân viên.",
                DataType = VariableDataType.Integer,
            },

            new SalarySystemVariable
            {
                Name = "is_holiday",
                DisplayName = "Ngày nghỉ",
                Description = "Kiểm tra nếu ngày chấm công là ngày nghỉ.",
                DataType = VariableDataType.Boolean,
            },

            new SalarySystemVariable
            {
                Name = "current_day",
                DisplayName = "Ngày hiện tại", 
                Description = "Xác định ngày trong tháng của ca làm việc.",
                DataType = VariableDataType.Integer,
            },

            new SalarySystemVariable
            {
                Name = "current_month",
                DisplayName = "Tháng hiện tại",
                Description = "Xác định tháng trong năm của ca làm việc.",
                DataType = VariableDataType.Integer,
            },

            new SalarySystemVariable
            {
                Name = "current_year",
                DisplayName = "Năm hiện tại",
                Description = "Xác định năm của ca làm việc",
                DataType = VariableDataType.Integer,
            },

            new SalarySystemVariable
            {
                Name = "salary_per_day",
                DisplayName = "Lương cơ bản mỗi ngày",
                Description = "Xác định lương trong ngày của nhân viên",
                DataType = VariableDataType.Integer,
            }
        };

        private EmsContext _context;
        private WorkingShiftTimekeeping _timekeeping;
        private User _user;
        private WorkingShift _event;
        public TimekeepingVariableBinder(
            EmsContext context,
            User user,
            WorkingShiftTimekeeping timekeeping)
        {
            _context = context;
            _timekeeping = timekeeping;
            _user = user;
            _event = initializeWorkingShiftEvent();
        }

        private WorkingShift initializeWorkingShiftEvent()
        {
            _context.Entry(_timekeeping).Reference(r => r.WorkingShiftEvent).Load();

            if (_timekeeping.WorkingShiftEvent == null)
            {
                throw new Exception("Working Shift Event Not Inititialized");
            }

            return _timekeeping.WorkingShiftEvent;
        }

        public bool ContainsVariable(string name)
        {
            return _systemVariables.Any(v => v.Name == name);
        }

        public void BindExpression(Expression expression, string name)
        {
            if (!ContainsVariable(name))
            {
                throw new Exception("System variable not found");
            }

            switch (name)
            {
                case "checkin_minutes_late":
                    expression.Bind(name, GetCheckInMinutesLate());
                    break;
                case "checkout_minutes_early":
                    expression.Bind(name, GetCheckOutMinutesEarly());
                    break;
                case "current_month":
                    expression.Bind(name, GetCurrentMonth());
                    break;
                case "current_year":
                    expression.Bind(name, GetCurrentYear());
                    break;
                case "current_day":
                    expression.Bind(name, GetCurrentDay());
                    break;
                case "salary_per_day":
                    expression.Bind(name, GetSalaryPerDay());
                    break;
                default:
                    throw new Exception("Variable Not Found");
            }
        }

        public int GetCheckInMinutesLate()
        {
            if (_timekeeping.CheckinTime == null)
            {
                return 0;
            }

            return _timekeeping.CheckinTime.Value.Subtract(_event.StartTime).Minutes;
        }

        public int GetCheckOutMinutesEarly()
        {
            if (_timekeeping.CheckoutTime == null)
            {
                return 0;
            }

            return -_timekeeping.CheckoutTime.Value.Subtract(_event.EndTime).Minutes;
        }

        public int GetCurrentDay()
        {
            return _event.StartTime.Day;
        }

        public int GetCurrentMonth()
        {
            return _event.StartTime.Month;
        }

        public int GetCurrentYear()
        {
            return _event.StartTime.Year;
        }

        public decimal GetSalaryPerDay()
        {
            var year = _event.StartTime.Year;
            var month = _event.StartTime.Month;
            var lastDayOfMonth = DateTime.DaysInMonth(year, month);

            var startOfMonth = new DateTime(year, month, 1, 0, 0, 1);
            var endOfMonth = new DateTime(year, month, lastDayOfMonth, 23, 59, 59);

            var numberOfShifts = _context.WorkingShifts
                .Where(evt => evt.Type == WorkingShiftType.FIXED_SHIFT)
                .Where(evt => evt.StartTime >= startOfMonth &&
                    evt.EndTime <= endOfMonth)
                .Count();

            return _user.BaseSalary / numberOfShifts;
        }

        public static List<SalarySystemVariable> GetSystemVariables()
        {
            return _systemVariables.Concat(
                UserVariableBinder.GetSystemVariables())
                .ToList();
        }
    }
}
