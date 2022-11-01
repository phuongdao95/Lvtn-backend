using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Services.Services;

namespace lvtn_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryGroupController : Controller
    {
        private readonly IMapper _mapper;
        private readonly SalaryGroupService _groupService;
        public SalaryGroupController(
            IMapper mapper,
            SalaryGroupService groupService)
        {
            _mapper = mapper;
            _groupService = groupService;
        }

        [HttpGet]
        public IActionResult GetGroupList([FromQuery] string? query = "")
        {
            try
            {
                var groupList = _groupService.GetSalaryGroupList(query);
                var data = _mapper.Map<IEnumerable<SalaryGroupInfoDTO>>(groupList);
                var total  = groupList.Count();
                var count = groupList.Count();

                return Ok(new Dictionary<string, object>()
                {
                    {"data", data},
                    {"total", total },
                    {"count", count }
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
