using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Services.Contracts;

namespace lvtn_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryGroupController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISalaryGroupService _groupService;
        public SalaryGroupController(IMapper mapper, ISalaryGroupService groupService)
        {
            _mapper = mapper;
            _groupService = groupService;
        }

        [HttpGet]
        public IActionResult GetGroupList(
            [FromQuery] int offset = 0,
            [FromQuery] int limit = 8,
            [FromQuery] string? query = "",
            [FromQuery] string? queryType = "name")
        {
            try
            {
                var groupList = _groupService.GetSalaryGroupList(offset, limit, query, queryType);
                var groupListTotal = _groupService.GetSalaryGroupCount(offset, limit, query, queryType);
                var groupInfoList = _mapper.Map<IEnumerable<SalaryGroupInfoDTO>>(groupList);

                return Ok(new Dictionary<string, object>()
                {
                    {"data", groupInfoList},
                    {"total", groupListTotal},
                    {"count", groupInfoList.Count() }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody] SalaryGroupDTO groupDTO)
        {
            try
            {
                _groupService.CreateSalaryGroup(groupDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetGroupById(int id)
        {
            try
            {
                var group = _groupService.GetSalaryGroupById(id);
                return Ok(_mapper.Map<SalaryGroupInfoDTO>(group));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGroup(int id, SalaryGroupDTO groupDTO)
        {
            try
            {
                _groupService.UpdateSalaryGroup(id, groupDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGroup(int id)
        {
            try
            {
                _groupService.DeleteSalaryGroup(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
