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
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            try
            {
                var department = _departmentService.GetDepartmentById(id);
                var departmentInfo = _mapper.Map<DepartmentInfoDTO>(department);
                return Ok(departmentInfo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult GetDepartmentList(
            [FromQuery] int offset = 0,
            [FromQuery] int limit = 20,
            [FromQuery] string? query = "",
            [FromQuery] string? queryType = "name")
        {
            try
            {
                var departmentList = _departmentService.GetDepartmentList(
                    offset,
                    limit,
                    query,
                    queryType
                );

                var departmentInfo = _mapper.Map<IEnumerable<DepartmentInfoDTO>>(departmentList);

                return Ok(new Dictionary<string, object>
                {
                    {"data", departmentInfo },
                    {"count", departmentInfo.Count() },
                    {"total", _departmentService.GetDepartmentCount()}
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult AddDepartment(DepartmentDTO departmentDTO)
        {
            try
            {
                _departmentService.AddDepartment(departmentDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                _departmentService.DeleteDepartmentById(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, DepartmentDTO departmentDTO)
        {
            try
            {
                _departmentService.UpdateDepartment(id, departmentDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(); 
            }
        }

        [HttpGet("{id}/team")]
        public IActionResult GetTeamsOfDepartment(int id)
        {
            try
            {
                var teams = _departmentService.GetTeamsOfDepartment(id);

                var data = _mapper.Map<IEnumerable<TeamInfoDTO>>(teams);
                var count = data.Count();
                var total = data.Count();
                return Ok(new Dictionary<string, object>
                {
                    {"data", data },
                    {"count", count },
                    {"total", total }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
