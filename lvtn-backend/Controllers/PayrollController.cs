using AutoMapper;
using AutoMapper.Configuration.Conventions;
using DocumentFormat.OpenXml.Office2010.Excel;
using lvtn_backend.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.Models;
using Models.Repositories.DataContext;
using Services.SalaryManagement.Exporters;
using Services.Services;
using System.Net.Mime;

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
        private readonly PayrollExporter _payrollExporter;
        private readonly PayslipExporter _payslipExporter;
        private readonly EmsContext _context;

        public PayrollController(
            IMapper mapper,
            PayrollService payrollService,
            NotificationService notificationService,
            IHubContext<NotificationHub> notificationHubContext,
            PayrollExporter payrollExporter,
            PayslipExporter payslipExporter,
            EmsContext context)
        {
            _mapper = mapper;
            _payrollService = payrollService;
            _notificationHubContext = notificationHubContext;
            _notificationService = notificationService;
            _context = context;
            _payrollExporter = payrollExporter;
            _payslipExporter = payslipExporter;
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
                _notificationHubContext.Clients.All.SendAsync("receiveMessage", "refreshNotification");

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpGet("/api/payroll/{id}/export")]
        public IActionResult ExportPayroll(int id)
        {
            try
            {
                return File(_payrollExporter.Export(id), "application/vnd.ms-excel");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpGet("/api/payslip/{id}/export")]
        public IActionResult ExportPayslip(int id)
        {
            try
            {
                return File(_payslipExporter.Export(id), "application/vnd.ms-excel");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //[HttpGet("/api/payslip/{id}/issue")]
        //public IActionResult LoadPayslipIssue(int id)
        //{
        //    try
        //    {
        //        var payslip = _context.Payslips
        //            .Include(payslip => payslip.Timekeepings)
        //                .ThenInclude(timekeeping => timekeeping.Issues)
        //            .Include(payslip => payslip.SalaryDeltas)
        //                .ThenInclude(salarydelta => salarydelta.Issues)
        //            .Where(payslip => id == payslip.Id)
        //            .SingleOrDefault();

        //        if (payslip is null)
        //        {
        //            return NotFound();
        //        }

        //        var timekeepingIssues = payslip.Timekeepings
        //            .SelectMany(timekeeping => timekeeping.Issues)
        //            .ToList();

        //        var salarydeltaIssues = payslip.SalaryDeltas
        //            .SelectMany(salarydelta => salarydelta.Issues)
        //            .ToList();

        //        var result = new Dictionary<string, object>();

        //        result["timekeepingIssues"] = timekeepingIssues.Select(issue => new
        //        {
        //            content = issue.Content,
        //            createdBy = issue.CreatedById,
        //            createdAt = issue.CreatedAt,
        //            resolved = issue.Resolved,
        //            resolvedBy = issue.ResolvedBy,
        //            timekeepingId = issue.TimekeepingId
        //        }).ToList();


        //        result["salarydeltaIssues"] = salarydeltaIssues.Select(issue => new
        //        {
        //            content = issue.Content,
        //            createdBy = issue.CreatedById,
        //            createdAt = issue.CreatedAt,
        //            resolved = issue.Resolved,
        //            resolvedBy = issue.ResolvedBy,
        //            salarydeltaId = issue.SalaryDeltaId,
        //        }).ToList();

        //        return Ok(result);
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}



        //[HttpPut("/api/{userId}/timekeepingissue/{id}/markresolve")]
        //public IActionResult MarkTimekeepingIssueAsResolved(int userId, int id)
        //{
        //    try
        //    {
        //        var timekeepingIssue = _context.PayslipTimekeepingIssues
        //            .Where(x => x.Id == id)
        //            .SingleOrDefault();

        //        var user = _context.Users
        //            .Where(x => x.Id == userId)
        //            .SingleOrDefault();

        //        if (timekeepingIssue is null || user is null)
        //        {
        //            return NotFound();
        //        }

        //        timekeepingIssue.Resolved = true;
        //        timekeepingIssue.ResolvedById = user.Id;

        //        _context.Add(timekeepingIssue);
        //        _context.SaveChanges();

        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpPut("/api/{userId}/salarydeltaissue/{id}/markresolve")]
        //public IActionResult MarkSalaryDeltaIssueAsResolved(int userId, int id)
        //{
        //    try
        //    {
        //        var salarydeltaIssue = _context.PayslipSalaryDeltaIssues
        //                .Where(x => x.Id == id)
        //                .SingleOrDefault();

        //        var user = _context.Users
        //            .Where(x => x.Id == id)
        //            .SingleOrDefault();

        //        if (salarydeltaIssue is null || user is null)
        //        {
        //            return NotFound();
        //        }

        //        salarydeltaIssue.Resolved = true;
        //        salarydeltaIssue.ResolvedById = userId;

        //        _context.Add(salarydeltaIssue);
        //        _context.SaveChanges();

        //        return Ok();
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }
        //}


        [HttpPost("/api/payslip/{id}/recalculation")]
        public IActionResult RecalculatePayslip(int id)
        {
            try
            {
                /** TODO */
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPut("/api/issue/{id}/resolution")]
        public IActionResult ResolveIssue(int id, ResolveIssueDTO issueDTO)
        {
            try
            {
                var issue = _context.PayslipIssues.Find(id);
                var user = _context.Users.Find(issueDTO.UserId);

                if (issue is null || user is null)
                {
                    return NotFound();
                }

                issue.IsResolved = true;
                issue.ResolvedAt = DateTime.Now;
                issue.ResolvedBy = user;

                _context.SaveChanges();

                return Ok();
            }   
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("/api/payslip/{id}/issue")]
        public IActionResult CreateIssue(int id, IssueDTO issue)
        {
            try
            {
                var payslip = _context.Payslips.Find(id);

                if (payslip is null)
                {
                    return NotFound();
                }

                _context.Add(new PayslipIssue
                {
                    Name = issue.Name,
                    Content = issue.Content,
                    IsResolved = false,
                    CreatedById = issue.UserId,
                    CreatedAt = DateTime.Now,
                    ResolvedById = null,
                    ResolvedAt = null,
                    PayslipId = payslip.Id,
                });

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/payroll/{id}/issue")]
        public IActionResult GetPayrollIssues(int id)
        {
            try
            {
                var payroll = _context.Payrolls.Find(id);
                
                if (payroll is null)
                {
                    return NotFound();
                }

                var issues = _context.Payslips
                    .Where(p => p.PayrollId == id)
                    .SelectMany(p => p.Issues)
                    .Include(issue => issue.CreatedBy)
                    .Include(issue => issue.ResolvedBy)
                    .Include(issue => issue.Payslip)
                    .OrderByDescending(issue => issue.IsResolved)
                    .OrderByDescending(issue => issue.CreatedAt)
                    .ToList();

                var serializedIssues = new List<Dictionary<string, object>>();

                foreach (var issue in issues)
                {
                    serializedIssues.Add(new Dictionary<string, object>
                    {
                        ["id"] = issue.Id,
                        ["name"] = issue.Name,
                        ["payslipId"] = issue.Payslip.Id,
                        ["payslipName"] = issue.Payslip?.Name ?? string.Empty,
                        ["content"] = issue.Content,
                        ["resolved"] = issue.IsResolved ? "Đã giải quyết" : "Chưa giải quyết",
                        ["createdAt"] = issue.CreatedAt.ToString() ?? string.Empty,
                        ["createdBy"] = issue.CreatedBy?.Name ?? string.Empty,
                        ["resolvedAt"] = issue.ResolvedAt.ToString() ?? string.Empty,
                        ["resolvedBy"] = issue.ResolvedBy?.Name ?? string.Empty,
                    });
                }

                return Ok(serializedIssues);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/payslip/{id}/issue")]
        public IActionResult GetPayslipIssues(int id)
        {
            try
            {
                var payslip = _context.Payslips.Find(id);

                if (payslip is null)
                {
                    return NotFound();
                }

                var issues = _context.PayslipIssues
                    .Include(p => p.CreatedBy)
                    .Include(p => p.ResolvedBy)
                    .Where(issue => issue.PayslipId == id)
                    .OrderByDescending(issue => issue.IsResolved)
                    .OrderByDescending(issue => issue.CreatedAt)
                    .ToList();

                var serializedIssues = new List<Dictionary<string, object>>();

                foreach (var issue in issues)
                {
                    serializedIssues.Add(new Dictionary<string, object>
                    {
                        ["id"] = issue.Id,
                        ["payslipId"] = payslip.Id,
                        ["payslipName"] = payslip.Name,
                        ["content"] = issue.Content,
                        ["resolved"] = issue.IsResolved,
                        ["createdAt"] = issue.CreatedAt,
                        ["createdBy"] = issue.CreatedBy?.Name ?? string.Empty,
                        ["resolvedAt"] = issue.ResolvedAt,
                        ["resolvedBy"] = issue.ResolvedBy?.Name ?? string.Empty,
                    });
                }

                return Ok(serializedIssues);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/issue/{id}")]
        public IActionResult GetIssueDetail(int id)
        {
            try
            {
                var issue = _context.PayslipIssues
                    .Where(issue => id == issue.Id)
                    .SingleOrDefault();

                if (issue is null)
                {
                    return NotFound();
                }

                return Ok(new Dictionary<string, object>
                {
                    ["id"] = issue.Id,
                    ["name"] = issue.Name,
                    ["content"] = issue.Content,
                    ["payslipId"] = issue.PayslipId,
                    ["createdAt"] = issue.CreatedAt,
                    ["createdBy"] = issue.CreatedBy?.Name ?? string.Empty,
                    ["resolved"] = issue.IsResolved,
                    ["resolvedAt"] = issue.ResolvedAt,
                    ["resolvedBy"] = issue.ResolvedBy?.Name ?? string.Empty,
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("/api/issue/{id}/comment")]
        public IActionResult CreateComment(int id, IssueCommentDTO comment)
        {
            try
            {
                var issue = _context.PayslipIssues.Find(id);

                if (issue is null)
                {
                    return NotFound();
                }

                _context.PayslipIssueComments.Add(
                    new PayslipIssueComment
                    {
                        UserId = comment.UserId,
                        Content = comment.Content,
                        CreatedAt = DateTime.Now,
                        IssueId = issue.Id,
                    });

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/issue/{id}/comment")]
        public IActionResult GetComments(int id)
        {
            try
            {
                var serializedComments = new List<Dictionary<string, object>>();     

                var comments = _context.PayslipIssueComments
                    .Include(comment => comment.User)
                    .Where(comment => comment.IssueId == id)
                    .OrderByDescending(comment => comment.CreatedAt)
                    .ToList();
                
                foreach (var comment in comments)
                {
                    serializedComments.Add(new Dictionary<string, object>
                    {
                        ["id"] = comment.Id,
                        ["content"] = comment.Content,
                        ["createdAt"] = comment.CreatedAt.ToString() ?? string.Empty,
                        ["userId"] = comment.UserId,
                        ["userName"] = comment.User?.Name ?? string.Empty,
                    });
                }

                return Ok(new Dictionary<string, object>
                {
                    ["comments"] = serializedComments
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
