using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Services.Services;

namespace lvtn_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayrollController : Controller
    {
        private readonly IMapper _mapper;
        private readonly PayrollService _payrollService;
        public PayrollController(IMapper mapper,
            PayrollService payrollService)
        {
            _mapper = mapper;
            _payrollService = payrollService;
        }

        [HttpPost]
        public IActionResult CreatePayroll(PayrollDTO payrollDTO)
        {
            try
            {
                _payrollService.CreatePayroll(payrollDTO);
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
                var payroll = _payrollService.GetPayrollList(offset, limit, query, queryType);
                var payrollListCount = _payrollService.GetPayrollListCount(offset, limit, query, queryType);
                var payrollInfo = _mapper.Map<IEnumerable<PayrollInfoDTO>>(payroll);

                return Ok(new Dictionary<string, object>
                {
                    { "data", payrollInfo },
                    { "total", payrollListCount },
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

        [HttpGet("/api/payslip/{id}")]
        public IActionResult GetPayslipDetail(int id)
        {
            return Ok();
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
    }
}
