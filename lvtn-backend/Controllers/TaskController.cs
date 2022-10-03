using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace lvtn_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMapper _mapper;
        public TaskController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("/taskboard")]
        public IActionResult GetTaskBoardsOfTeam(int teamId)
        {
            return Ok();
        }

        [HttpPost("/taskboard")]
        public IActionResult CreateTaskBoard()
        {
            return Ok();
        }

        [HttpPut("/taskboard/{id}")]
        public IActionResult UpdateTaskBoard(int id)
        {
            return Ok();
        }

        [HttpDelete("/taskboard/{id}")]
        public IActionResult DeleteTaskBoard(int id)
        {
            return Ok();
        }

        [HttpGet("/taskboard/{boardId}/column")]
        public IActionResult GetTaskColumnsOfTaskBoard(int boardId)
        {
            return Ok();
        }

        [HttpGet("/taskboard/{boardId}/task")]
        public IActionResult GetTasksOfBoard(int boardId)
        {
            return Ok();
        }

        [HttpDelete("/taskcolumn/{id}")]
        public IActionResult DeleteTaskColumn(int id)
        {
            return Ok();
        }

        [HttpPut("/taskcolumn/{id}")]
        public IActionResult UpdateTaskColumn(int id)
        {
            return Ok();
        }

        [HttpPost("/taskcolumn")]
        public IActionResult CreateTaskColumn(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateTask()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTask()
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            return Ok();
        }

        [HttpGet("/task/{taskId}/taskcomment")]
        public IActionResult GetTaskCommentsOfTask(int taskId)
        {
            return Ok();
        }

        [HttpPut("/task/{taskId}/taskcomment/{commentId}")]
        public IActionResult UpdateTaskCommentsOfTask()
        {
            return Ok();
        }

        [HttpPost("/task/{taskId}/taskcomment/")]
        public IActionResult CreateTaskCommentOfTask()
        {
            return Ok();
        }
    }
}
