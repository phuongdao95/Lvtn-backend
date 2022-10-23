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
    public class TaskBoardController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly TaskBoardService _taskBoardService;
        public TaskBoardController(IMapper mapper, TaskBoardService taskBoardService)
        {
            _mapper = mapper;
            _taskBoardService = taskBoardService;
        }

        [HttpGet("/api/taskboard/{id}/user")]
        public IActionResult GetUsersOfTaskBoard(int id)
        {
            try
            {
                var userList = _taskBoardService.GetUsersOfBoard(id);
                var userListInfo = _mapper.Map<IEnumerable<UserInfoDTO>>(userList);

                var data = userListInfo;
                var count = userListInfo.Count();
                var total = userListInfo.Count();

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

        [HttpGet("/api/user/{id}/taskboard")]
        public IActionResult GetTaskBoardListOfUser(int id)
        {
            try
            {
                var taskBoardList = _taskBoardService.GetTaskBoardListOfUser(id);

                var data = _mapper.Map<IEnumerable<TaskBoardInfoDTO>>(taskBoardList);
                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>()
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


        [HttpPut("{id}")]
        public IActionResult UpdateTaskBoard(int id, TaskBoardDTO taskBoardDTO)
        {
            try
            {
                _taskBoardService.UpdateTaskBoard(id, taskBoardDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateTaskBoard(TaskBoardDTO taskBoardDTO)
        {
            try
            {
                _taskBoardService.CreateTaskBoard(taskBoardDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBoard(int id)
        {
            try
            {
                _taskBoardService.DeleteTaskBoard(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetBoardById(int id)
        {
            try
            {
                var taskBoard = _taskBoardService.GetTaskBoardById(id);
                var taskBoardInfo = _mapper.Map<TaskBoardInfoDTO>(taskBoard);

                return Ok(taskBoardInfo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/taskcolumn/{id}/task")]
        public IActionResult GetTasksOfTaskColumn(int id)
        {
            try
            {
                var task = _taskBoardService.GetTasksOfTaskColumn(id);
                var data = _mapper.Map<IEnumerable<TaskInfoDTO>>(task);
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

        [HttpGet("/api/taskboard/{id}/tasklabel")]
        public IActionResult GetTaskLabelsOfBoard(int id)
        {
            try
            {
                var taskColumns = _taskBoardService.GetTaskLabelsOfBoard(id);

                var data = _mapper.Map<IEnumerable<TaskLabelInfoDTO>>(taskColumns);
                var count = data.Count();
                var total = data.Count();
                return Ok(new Dictionary<string, object>()
                {
                    {"data", data },
                    {"total", total },
                    { "count", count }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/tasklabel/{id}")]
        public IActionResult GetTaskLabelById(int id)
        {
            try
            {
                var taskLabel = _taskBoardService.GetTaskLabelById(id);
                var mapped = _mapper.Map<TaskLabelInfoDTO>(taskLabel);
                return Ok(mapped);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/taskboard/{id}/taskcolumn")]
        public IActionResult GetTaskColumnsOfBoard(int id)
        {
            try
            {
                var taskColumns = _taskBoardService.GetTaskColumnsOfBoard(id);

                var data = _mapper.Map<IEnumerable<TaskColumnInfoDTO>>(taskColumns);
                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>()
                {
                    {"data", data },
                    {"total", total },
                    {"count", count }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("/api/tasklabel/")]
        public IActionResult CreateTaskLabelForBoard(TaskLabelDTO taskLabelDTO)
        {
            try
            {
                _taskBoardService.CreateTaskLabel(taskLabelDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("/api/tasklabel/{id}")]
        public IActionResult UpdateTaskLabelForBoard(int id, TaskLabelDTO taskLabelDTO)
        {
            try
            {
                _taskBoardService.UpdateTaskLabel(id, taskLabelDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpDelete("/api/tasklabel/{id}")]
        public IActionResult DeleteTaskLabel(int id)
        {
            try
            {
                _taskBoardService.DeleteTaskLabel(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("/api/taskcolumn/")]
        public IActionResult CreateTaskColumnForBoard(TaskColumnDTO taskColumnDTO)
        {
            try
            {
                _taskBoardService.CreateTaskColumn(taskColumnDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("/api/taskcolumn/{id}")]
        public IActionResult UpdateTaskColumnForBoard(int id, TaskColumnDTO taskColumnDTO)
        {
            try
            {
                _taskBoardService.UpdateTaskColumn(id, taskColumnDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("/api/taskcolumn/{id}")]
        public IActionResult DeleteTaskColumn(int id)
        {
            try
            {
                _taskBoardService.DeleteTaskColumn(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
