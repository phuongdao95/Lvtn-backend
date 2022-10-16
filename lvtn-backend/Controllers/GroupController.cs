using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.DTO.Response;
using Services.Contracts;

namespace lvtn_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private IMapper _mapper;
        public GroupController(IMapper mapper, IGroupService groupService)
        {
            _mapper = mapper;
            _groupService = groupService;
        }

        [HttpGet("{id}")]
        public IActionResult GetGroupById(int id)
        {
            try
            {
                var group = _groupService.GetGroupById(id, true);
                var groupInfo = _mapper.Map<GroupInfoDTO>(group);
                return Ok(group);
            }
            catch (Exception)
            {
                return BadRequest();
            }
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
                var group = _groupService.GetGroupList(offset, limit, query, queryType);
                var data = _mapper.Map<IEnumerable<GroupInfoDTO>>(group);
                var total = _groupService.GetGroupListCount(query, queryType);
                var count = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    {"data", data },
                    {"count", count},
                    {"total", total},
                });
                
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

        [HttpPost]
        public IActionResult CreateGroup(GroupDTO groupDTO)
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
    }
}
