using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Services.Contracts;

namespace lvtn_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGroupService _groupService;
        public GroupController(IMapper mapper, IGroupService groupService)
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
                var groupList = _groupService.GetGroupList(offset, limit, query, queryType);
                var groupListTotal = _groupService.GetGroupListCount(offset, limit, query, queryType);
                var groupInfoList = _mapper.Map<IEnumerable<GroupInfoDTO>>(groupList);

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
        public IActionResult CreateGroup([FromBody] GroupDTO groupDTO)
        {
            try
            {
                _groupService.CreateGroup(groupDTO);
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
                var group = _groupService.GetGroupById(id);
                return Ok(
                 _mapper.Map<GroupInfoDTO>(group));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGroup(int id, GroupDTO groupDTO)
        {
            try
            {
                _groupService.UpdateGroup(id, groupDTO);
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
                _groupService.DeleteGroup(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
