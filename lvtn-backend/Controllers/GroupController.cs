using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace lvtn_backend.Controllers
{
    public class GroupController : ControllerBase
    {
        private readonly IMapper _mapper;
        public GroupController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IActionResult GetGroup()
        {
            return Ok();
        }
    }
}
