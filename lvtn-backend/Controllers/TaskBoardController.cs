using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace lvtn_backend.Controllers
{
    public class TaskBoardController : ControllerBase
    {

        private readonly IMapper _mapper;
        public TaskBoardController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBoardList(
            [FromQuery] int offset, 
            [FromQuery] int limit, 
            [FromQuery] string? query,
            [FromQuery] string? queryType)
        {
            return Ok();
        }

        [HttpGet("user/{id}/board")]
        public IActionResult GetBoardListOfUser(int id)
        {
            return Ok();
        }


        [HttpPut]
        public IActionResult UpdateBoard(int id)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteBoard(int id)
        {
            return Ok();
        }


        [HttpGet("{id}")]
        public IActionResult GetBoardById(int id)
        {
            return Ok();
        }
    }
}
