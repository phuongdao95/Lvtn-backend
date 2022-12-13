using AutoMapper;
using lvtn_backend.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Services;

namespace lvtn_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PayrollController : Controller
    {
        private readonly IMapper _mapper;
        private readonly PayrollService _payrollService;
        private readonly NotificationService _notificationService;
        private readonly IHubContext<NotificationHub> _notificationHubContext;
        private readonly EmsContext _context;

        public PayrollController(
            IMapper mapper,
            PayrollService payrollService,
            NotificationService notificationService,
            IHubContext<NotificationHub> notificationHubContext,
            EmsContext context)
        {
            _mapper = mapper;
            _payrollService = payrollService;
            _notificationHubContext = notificationHubContext;
            _notificationService = notificationService;
            _context = context;
        }


        [HttpPost]
        public IActionResult CreatePayroll(PayrollDTO payrollDTO)
        {
            try
            {
                _payrollService.CreatePayroll(payrollDTO);
                _notificationService.AddNotificationForAllUser(new Notification
                {
                    DateTime = DateTime.Now,
                    IsGlobal = true,
                    IsRead = false,
                    Title =  "Payroll được tạo mới",
                    Message = $"Payroll {payrollDTO.Name} đã được tạo mới."
                });

                _notificationHubContext.Clients.All.SendAsync("receiveMessage", "refreshNotification");
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetPayrollList(
            [FromQuery] int offset = 0,
            [FromQuery] int limit = 8,
            [FromQuery] string? query = "",
            [FromQuery] string? queryType = "name")
        {
            try
            {
                var payroll = _payrollService.GetPayrollList(offset, int.MaxValue, query, queryType);
                var payrollInfo = _mapper.Map<IEnumerable<PayrollInfoDTO>>(payroll);

                return Ok(new Dictionary<string, object>
                {
                    { "data", payrollInfo },
                    { "total", payroll.Count() },
                    { "count", payrollInfo.Count() }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPayrollById(int id)
        {
            try
            {
                var payroll = _payrollService.GetPayrollById(id);
                var payrollInfo = _mapper.Map<PayrollInfoDTO>(payroll);

                return Ok(payrollInfo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}/payslip")]
        public IActionResult GetPayslipsOfPayroll(int id)
        {
            try
            {
                var payslips = _payrollService.GetPayslipsOfPayroll(id);
                var payslipInfos = _mapper.Map<IEnumerable<PayslipInfoDTO>>(payslips);

                var data = payslipInfos;
                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    {"data", payslipInfos},
                    {"count", count},
                    {"total", total},
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePayroll(int id, PayrollDTO payrollDTO)
        {
            try
            {
                _payrollService.UpdatePayroll(id, payrollDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePayroll(int id)
        {
            try
            {
                _payrollService?.DeletePayroll(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet("/api/payslip/{id}/timekeeping")]
        public IActionResult GetPayslipTimekeepingList(int id)
        {
            try
            {
                var timekeepings = _payrollService.GetPayslipTimekeepings(id);

                var data = _mapper
                    .Map<IEnumerable<PayslipTimekeepingInfoDTO>>(timekeepings)
                    .ToList();

                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    { "data", data },
                    { "count", count },
                    { "total", total }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet("/api/user/{id}/payslip")]
        public IActionResult GetPayslipListOfUser(int id)
        {
            try
            {
                var payslips = _payrollService.GetPayslipsOfUser(id);

                var data = _mapper.Map<IEnumerable<PayslipInfoDTO>>(payslips);
                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    { "data", data },
                    { "total", total },
                    { "count", count }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/payslip/{id}")]
        public IActionResult GetPayslipById(int id)
        {
            try
            {
                var payslip = _payrollService.GetPayslipById(id);
                var data = _mapper.Map<PayslipInfoDTO>(payslip);

                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/payslip/{id}/salarydelta")]
        public IActionResult GetPayslipSalaryDelta(int id)
        {
            try
            {
                var salaryDeltas = _payrollService.GetPayslipSalaryDeltas(id);

                var data = _mapper
                    .Map<IEnumerable<PayslipSalaryDeltaInfoDTO>>(salaryDeltas)
                    .ToList();

                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    { "data", data },
                    { "count", count },
                    { "total", total }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}/report/")]
        public IActionResult GetPayrollReport(int id)
        {
            try
            {
                var payslips = _context.Payslips.Where(payslip => payslip.PayrollId == id)
                    .Include(payslip => payslip.Employee)
                    .ToList();

                var totalEmployee = payslips.Count();

                decimal totalDeduction = payslips
                    .Select(payslip => payslip.TotalDeduction ?? decimal.Zero)
                    .Aggregate(decimal.Zero, (result, item) => result + item);

                decimal totalAllowance = payslips
                    .Select(payslip => payslip.TotalAllowance ?? decimal.Zero)
                    .Aggregate(decimal.Zero,(result, item) => result + item);

                decimal totalBonus = payslips
                    .Select(payslip => payslip.TotalBonus ?? decimal.Zero)
                    .Aggregate(decimal.Zero, (result, item) => result + item);

                decimal totalActualSalary = payslips
                    .Select(payslip => payslip.ActualSalary ?? decimal.Zero)
                    .Aggregate(decimal.Zero, (result, item) => result + item);

                var top10PayslipOrderByBonus = payslips
                    .OrderByDescending(p => p.TotalBonus ?? 0)
                    .Select(payslip => new { payslip.Employee.Name, payslip.Employee.Username, Value = payslip.TotalBonus } )
                    .OrderByDescending(x => x.Value)
                    .Take(10)
                    .ToList();

                var top10PayslipOrderByDeduction = payslips
                    .OrderByDescending(p => p.TotalBonus ?? 0)
                    .Select(payslip => new { payslip.Employee.Name, payslip.Employee.Username, Value = payslip.TotalDeduction })
                    .OrderByDescending(x => x.Value)
                    .Take(10)
                    .ToList();

                var top10PayslipOrderByAllowance = payslips
                    .OrderByDescending(p => p.TotalBonus ?? 0)
                    .Select(payslip => new { payslip.Employee.Name, payslip.Employee.Username, Value = payslip.TotalAllowance })
                    .OrderByDescending(x => x.Value)
                    .Take(10)
                    .ToList();

                var top10PayslipOrderByTotalSalary = payslips
                    .OrderByDescending(p => p.TotalBonus ?? 0)
                    .Select(payslip => new { payslip.Employee.Name, payslip.Employee.Username, Value = payslip.ActualSalary })
                    .OrderByDescending(x => x.Value)
                    .Take(10)
                    .ToList();

                return Ok(new Dictionary<string, object>
                {
                    ["totalActualSalary"] = totalActualSalary,
                    ["totalEmployee"] = totalEmployee,
                    ["totalAllowance"] = totalAllowance,
                    ["totalDeduction"] = totalDeduction,
                    ["totalBonus"] = totalBonus,
                    ["top10Allowance"] = top10PayslipOrderByAllowance,
                    ["top10Bonus"] = top10PayslipOrderByBonus,
                    ["top10Deduction"] = top10PayslipOrderByDeduction,
                    ["top10ActualSalary"] = top10PayslipOrderByTotalSalary
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("{id}/status")]
        public IActionResult SendPayroll(int id)
        {
            try
            {
                var payroll = _payrollService.GetPayrollById(id);
                _payrollService.SendPayroll(id);
                _notificationService.AddNotificationForAllUser(new Notification
                {
                    IsRead = false,
                    Message = $"Payslip {payroll.Name} đã được gửi",
                    Title = $"Payslip đã được gửi",
                    DateTime = DateTime.Now,
                });

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
