using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.Repositories.DataContext;
using Services.Contracts;

namespace lvtn_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayrollController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPayrollService _payrollService;
        public PayrollController(IMapper mapper, IPayrollService payrollService)
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

        [HttpGet("payroll/{id}/payslip")]
        public IActionResult GetPayslipsOfPayroll(
            [FromRoute] int id,
            [FromQuery] int offset = 0,
            [FromQuery] int limit = 8,
            [FromQuery] string? query = "",
            [FromQuery] string? queryType = "name")
        {
            try
            {
                var payslips = _payrollService.GetPayslipListOfPayroll(
                    id, offset, limit, query, queryType);

                var payslipInfo = _mapper.Map<IEnumerable<PayslipInfoDTO>>(payslips);
                var count = payslipInfo.Count();
                var total = _payrollService.GetPayslipListOfPayrollCount(
                    id, offset, limit, query, queryType);

                return Ok(new Dictionary<string, object>
                {
                    {"data", payslipInfo },
                    {"total", total },
                    {"count", count }
                });
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("api/payslip/{id}")]
        public IActionResult GetPayslipDetail(int id)
        {
            return Ok();
        }

        [HttpPut("api/payslip/{id}")]
        public IActionResult UpdatePayslip(int id)
        {
            return Ok();
        }
    }
}
