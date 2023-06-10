using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Services.Contracts;

namespace lvtn_backend.Controllers
{
    [Authorize]
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
            [FromQuery] int? offset = 0,
            [FromQuery] int? limit = 8,
            [FromQuery] string? query = "",
            [FromQuery] string? queryType = "")
        {
            try
            {
                var salaryDeltaList =  _salaryDeltaService.GetSalaryDeltaList(0, int.MaxValue, query, queryType);

                var data = _mapper.Map<IEnumerable<SalaryDeltaInfoDTO>>(salaryDeltaList); 
                var total = _salaryDeltaService.GetSalaryDeltaListCount(query, queryType);
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
        public IActionResult CreateSalaryDelta(SalaryDeltaDTO salaryDeltaDTO)
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
        public IActionResult DeleteSalaryDelta(int id)
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
    }
}
