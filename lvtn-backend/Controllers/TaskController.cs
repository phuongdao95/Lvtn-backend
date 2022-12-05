using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Services;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace lvtn_backend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly EmsContext _context;
        private readonly TaskService _taskService;
        private readonly TaskHistoryService _taskHistoryService;
        public TaskController(
            IMapper mapper,
            EmsContext context,
            TaskService taskService,
            TaskHistoryService taskHistoryService)
        {
            _mapper = mapper;
            _context = context;
            _taskService = taskService;
            _taskHistoryService = taskHistoryService;
        }


        [HttpPost]
        public IActionResult CreateTask(TaskDTO taskDTO)
        {
            try
            {
                _taskService.CreateTask(taskDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskDTO taskDTO)
        {
            try
            {
                _taskService.UpdateTask(id, taskDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                _taskService.DeleteTask(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            try
            {
                var task = _taskService.GetTaskById(id);
                var taskInfo = _mapper.Map<TaskInfoDTO>(task);

                return Ok(taskInfo);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}/tasklabel")]
        public IActionResult GetTaskLabels(int id)
        {
            try
            {
                var taskLabels = _taskService.GetTaskLabelsOfTask(id);
                var taskLabelsInfo = _mapper.Map<IEnumerable<TaskLabelInfoDTO>>(taskLabels);

                var data = taskLabelsInfo;
                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    { "data", data },
                    { "count", count },
                    { "total", total}
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("{id}/tasklabel/{tasklabelid}")]
        public IActionResult AddTaskLabel(int id, int tasklabelid)
        {
            try
            {
                _taskService.AddTaskLabel(id, tasklabelid);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}/tasklabel/{tasklabelid}")]
        public IActionResult RemoveTaskLabel(int id, int tasklabelid)
        {
            try
            {
                _taskService.RemoveTaskLabelFromTask(id, tasklabelid);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}/taskhistory")]
        public IActionResult GetTaskHistoryOfTask(int id)
        {
            try
            {
                var taskHistoryDTO = _taskHistoryService.GetTaskHistoriesOfTask(id);

                return Ok(new Dictionary<string, object>
                {
                    { "data", taskHistoryDTO },
                    { "count", taskHistoryDTO.Count() },
                    { "total", taskHistoryDTO.Count() }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpPut("/api/taskfile/{id}/")]
        public IActionResult UpdateTaskFile(int id, TaskFileDTO taskFileDTO)
        {
            try
            {
                var taskFile = _context.TaskFiles.Find(id);
                if (taskFile == null)
                {
                    throw new Exception("Task file not found");
                }
                taskFile.DisplayFileName = taskFileDTO.DisplayName;
                taskFile.Description = taskFile.Description;

                _context.TaskFiles.Update(taskFile);
                _context.SaveChanges();

                var task = _context.Tasks.Where(t => t.Id == taskFile.TaskId)
                    .Include(t => t.TaskHistories)
                    .Single();

                var taskHistory = _taskHistoryService.BuildTaskHistoryFromTaskFileAndTaskId(
                    task.Id,
                    taskFile,
                    TaskHistoryAction.UpdateFile);

                if (task.TaskHistories == null)
                {
                    throw new Exception();
                }

                task.TaskHistories.Add(taskHistory);
                _context.Tasks.Update(task);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}/taskfile")]
        public IActionResult GetTaskFiles(int id)
        {
            try
            {
                var taskFiles = _taskService.GetTaskFiles(id);
                var taskFileInfo = _mapper.Map<IEnumerable<TaskFileInfoDTO>>(taskFiles);

                var data = taskFileInfo;
                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    { "data", data },
                    { "count", count },
                    { "total", total }
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet("{id}/taskcomment")]
        public IActionResult GetTaskComments(int id)
        {
            try
            {
                var taskComments = _taskService.GetTaskComments(id);
                var data = _mapper.Map<IEnumerable<TaskCommentInfoDTO>>(taskComments);

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

        [HttpPost("{id}/taskcomment")]
        public IActionResult AddComment(int id, TaskCommentDTO taskCommentDTO)
        {
            try
            {
                _taskService.AddTaskComment(id, taskCommentDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}/taskcolumn/")]
        public IActionResult MoveTask(int id, [FromBody] MoveTaskDTO moveTaskDTO)
        {
            try
            {
                _taskService.MoveTask(id, moveTaskDTO);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("{id}/taskfile")]
        public IActionResult UploadTaskFile(
            int id,
            [FromBody] TaskFileDTO taskFileDTO)
        {
            try
            {
                var folderName = Path.Combine("Resources", "VirtualSpace");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                var fileName = string.Format(@"{0}", Guid.NewGuid());
                var filename = $"{fileName}.{taskFileDTO.Extension}";

                var fullPath = Path.Combine(pathToSave, filename);
                var filePath = Path.Combine(folderName, filename);

                Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
                var actualFile = regex.Replace(taskFileDTO.File, string.Empty);

                System.IO.File.WriteAllBytes(filePath, Convert.FromBase64String(actualFile));

                var taskFile = new TaskFile()
                {
                    DisplayFileName = taskFileDTO.DisplayName + "." + taskFileDTO.Extension,
                    Name = filename,
                    Description = taskFileDTO.Description,
                    TaskId = id,
                };

                _context.TaskFiles.Add(taskFile);
                _context.SaveChanges();

                var task = _context.Tasks.Where(t => t.Id == taskFile.TaskId)
                    .Include(t => t.TaskHistories)
                    .Single();

                var taskHistory = _taskHistoryService.BuildTaskHistoryFromTaskFileAndTaskId(task.Id, taskFile, TaskHistoryAction.AddFile);
                if (task.TaskHistories == null)
                {
                    throw new Exception();
                }

                task.TaskHistories.Add(taskHistory);

                _context.Tasks.Update(task);
                _context.SaveChanges();

                return Ok(new { filePath });

            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }


        [HttpPut("{id}/description")]
        public IActionResult UpdateTaskDescription(int id, TaskDTO taskDTO)
        {
            try
            {
                if (taskDTO.Description == null)
                {
                    throw new Exception();
                }

                _taskService.UpdateDescription(id, taskDTO.Description);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("/api/taskfile/{id}")]
        public IActionResult RemoveTaskFile(int id)
        {
            try
            {
                var taskFile = _context.TaskFiles.Find(id);
                if (taskFile == null)
                {
                    throw new Exception("Bad Request");
                }

                var folderName = Path.Combine("Resources", "VirtualSpace");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fullPath = Path.Combine(pathToSave, taskFile.Name);

                if (System.IO.File.Exists(fullPath))
                {
                    System.IO.File.Delete(fullPath);
                }

                _context.TaskFiles.Remove(taskFile);
                _context.SaveChanges();

                var task = _context.Tasks.Where(t => t.Id == taskFile.TaskId)
                    .Include(t => t.TaskHistories)
                    .Single();

                var taskHistory = _taskHistoryService.BuildTaskHistoryFromTaskFileAndTaskId(
                    task.Id, taskFile, TaskHistoryAction.DeleteFile);

                if (task.TaskHistories == null)
                {
                    throw new Exception();
                }

                task.TaskHistories.Add(taskHistory);

                _context.Tasks.Update(task);
                _context.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }

        [HttpGet("/api/taskfile/{id}")]
        public IActionResult GetTaskFileById(int id)
        {
            try
            {
                var taskFile = _taskService.GetTaskFileById(id);
                var data = _mapper.Map<TaskFileInfoDTO>(taskFile);
                return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpGet("/api/taskfile/{id}/download")]
        public IActionResult DownloadTaskFile(int id)
        {
            try
            {
                var taskFile = _context.TaskFiles.Find(id);
                if (taskFile == null)
                {
                    throw new Exception("File doesn't exists");
                }

                var folderName = Path.Combine("Resources", "VirtualSpace");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                var fullPath = Path.Combine(pathToSave, taskFile.Name);

                byte[] bytes = System.IO.File.ReadAllBytes(fullPath);

                return File(bytes, MediaTypeNames.Application.Octet, taskFile.DisplayFileName);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
