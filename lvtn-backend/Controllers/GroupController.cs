using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lvtn_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly object _groupService;
        private IMapper _mapper;
        public GroupController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetGroupById(int id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetGroupList(
             [FromQuery] int offset,
             [FromQuery] int limit,
             [FromQuery] string? query,
             [FromQuery] string? queryType)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveGroup(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateGroup()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGroup()
        {
            return Ok();
        }
    }
}
