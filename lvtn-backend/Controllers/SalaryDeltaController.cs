using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.Enums;
using Services.Contracts;
using System.Security.Cryptography;

namespace lvtn_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryDeltaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISalaryDeltaService _salaryDeltaService;
        public SalaryDeltaController(IMapper mapper, ISalaryDeltaService salaryDeltaService)
        {
            _mapper = mapper;
            _salaryDeltaService = salaryDeltaService;
        }

        [HttpGet]
        public IActionResult GetSalaryDeltaList(
            [FromQuery] int offset = 0, 
            [FromQuery] int limit = 8,
            [FromQuery] string? type = "deduction",
            [FromQuery] string? query = "",
            [FromQuery] string? queryType = "display_name")
        {
            try
            {
                SalaryDeltaType sdType;

                switch (type)
                {
                    case "deduction":
                        sdType = SalaryDeltaType.Deduction;
                        break; 
                    case "allowance":
                        sdType = SalaryDeltaType.Allowance;
                        break;
                    case "bonus":
                        sdType = SalaryDeltaType.Bonus;
                        break;
                    default:
                        sdType = SalaryDeltaType.Deduction;
                        break;
                }

                var salaryDeltaList =  _salaryDeltaService.GetSalaryDeltaList(offset, limit, sdType, query, queryType);

                var data = _mapper.Map<IEnumerable<SalaryDeltaInfoDTO>>(salaryDeltaList); 
                var total = _salaryDeltaService.GetSalaryDeltaListCount(offset, int.MaxValue, sdType, query, queryType);
                var count = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    {"data", data},
                    {"total", total},
                    {"count", count},   
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSalaryDeltaById(int id)
        {
            try
            {
                var salaryDelta = _salaryDeltaService.GetSalaryDeltaById(id);
                var mapped = _mapper.Map<SalaryDeltaInfoDTO>(salaryDelta);

                return Ok(mapped);
            } catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSalaryDeltaById(int id,
            SalaryDeltaDTO salaryDeltaDTO)
        {
            try
            {
                _salaryDeltaService.UpdateSalaryDelta(id, salaryDeltaDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateSalaryDelta([FromBody] SalaryDeltaDTO salaryDeltaDTO)
        {
            try
            {
                _salaryDeltaService.CreateSalaryDelta(salaryDeltaDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSalaryDelta([FromHeader] int id)
        {
            try 
            {
                _salaryDeltaService.DeleteSalaryDelta(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}/user/{userId}")]
        public IActionResult AddUserToSalaryDelta(
            [FromQuery] int id,
            [FromQuery] int userId)
        {
            return Ok();
        }
    }
}
