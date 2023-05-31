using AutoMapper;
using DocumentFormat.OpenXml.Office2013.WebExtentionPane;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DTO.Request;
using Models.DTO.Response;
using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using Services.MachineLearning;
using Services.MachineLearning.DataModels;
using Services.Services;
using System.Net.Mime;
using System.Text.RegularExpressions;
using Task = Models.Models.Task;

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
        private readonly TaskEstimationService _taskEstimationService;

        public TaskController(
            IMapper mapper,
            EmsContext context,
            TaskService taskService,
            TaskHistoryService taskHistoryService,
            TaskEstimationService taskEstimationService)
        {
            _mapper = mapper;
            _context = context;
            _taskService = taskService;
            _taskHistoryService = taskHistoryService;
            _taskEstimationService = taskEstimationService;
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

        [HttpGet("{id}/parenttask")]
        public IActionResult GetParentTaskOfTask()
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("{id}/reopen")]
        public IActionResult ReopenTask(int id, ReopenTaskDTO reopenTaskDTO)
        {
            try
            {
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet("{id}/subtask/")]
        public IActionResult GetSubTasksOfTask(int id)
        {
            try
            {
                var subTasks = _taskService.GetSubtasksOfTask(id);
                var data = _mapper.Map<IEnumerable<TaskInfoDTO>>(subTasks);
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

        [HttpPost("{id}/subtasks/")]
        public IActionResult CreateSubTasksOfTask(int id, TaskDTO taskDTO)
        {
            try
            {
                _taskService.CreateSubTaskOfTask(id, taskDTO);
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
                var fileName = string.Format(@"{0}", Guid.NewGuid());
                var filename = $"{fileName}.{taskFileDTO.Extension}";

                Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
                var actualFile = regex.Replace(taskFileDTO.File, string.Empty);


                var taskFile = new TaskFile()
                {
                    DisplayFileName = taskFileDTO.DisplayName + "." + taskFileDTO.Extension,
                    Name = filename,
                    Content = Convert.FromBase64String(actualFile),
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

                return Ok();

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
                if (taskFile is null || taskFile.Content is null)
                {
                    throw new Exception("File doesn't exists");
                }


                return File(taskFile.Content, MediaTypeNames.Application.Octet, taskFile.DisplayFileName);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        [HttpGet("/api/taskboard/{id}/report")]
        public IActionResult GetTaskBoardReport(int id)
        {
            try
            {
                var taskBoard = _context.TaskBoards.Where(board => board.Id == id)
                    .Include(taskBoard => taskBoard.TaskColumns)
                        .ThenInclude(taskColumn => taskColumn.Tasks)
                            .ThenInclude(task => task.InCharge)
                    .Include(taskBoard => taskBoard.TaskColumns)
                        .ThenInclude(TaskColumn => TaskColumn.Tasks)
                            .ThenInclude(task => task.TaskHistories)
                    .SingleOrDefault();

                if (taskBoard == null)
                {
                    throw new Exception("Cannot find taskboard");
                }

                var totalEmployee = _context.Users
                    .Where(user => user.TeamId == taskBoard.TeamId)
                    .Count();

                var taskDoneColumn = taskBoard.TaskColumns
                    .Where(column => column.Name == "Done")
                    .Single();
                
                var tasksDone = taskDoneColumn.Tasks;

                var totalTaskDone = tasksDone.Count();

                var taskNewColumn = taskBoard.TaskColumns
                    .Where(column => column.Name == "Todo")
                    .Single();

                var tasks = taskBoard.TaskColumns
                    .Aggregate(Enumerable.Empty<Task>(), (acc, rhs) =>
                        acc.Concat(rhs.Tasks is not null ? rhs.Tasks.AsEnumerable() : Enumerable.Empty<Task>()))
                    .ToList();

                var tasksOtherThanDone = taskBoard.TaskColumns
                    .Where(column => column.Name.ToLower() != "done")
                    .Aggregate(Enumerable.Empty<Task>(), (acc, rhs) =>
                        acc.Concat(rhs.Tasks is not null ? rhs.Tasks.AsEnumerable() : Enumerable.Empty<Task>()))
                    .ToList();


                var totalTaskNew = taskNewColumn.Tasks?.Count() ?? 0;
                var totalPointFinished = tasksDone.Aggregate(0, (acc, item) => acc + (item.Point ?? 0));

                var totalTaskFinishedByEightDays = getTotalTaskDoneByLastEightDays(tasksDone);
                var pointFinishedByEightDays = getTotalPointByLastEightDays(tasksDone);
                var totalTaskCreatedByEightDays = getTotalTaskCreatedByEightDays(tasks);
                var totalTaskLate = getTotalTaskLate(tasksOtherThanDone);
                var totalTaskEstimatedToBeLate = getTotalTaskEstimatedToBeLate(tasksOtherThanDone);

                return Ok(new Dictionary<string, object>
                {
                    ["totalEmployeeCount"] = totalEmployee,
                    ["totalTaskDone"] = totalTaskDone,
                    ["totalTaskLate"] = totalTaskLate,
                    ["totalPointFinished"] = totalPointFinished,
                    ["totalTaskEstimatedToBeLate"] = totalTaskEstimatedToBeLate,
                    ["totalTaskNew"] = totalTaskNew,
                    ["taskDoneByEightDays"] = totalTaskFinishedByEightDays,
                    ["pointFinishedByEightDays"] = pointFinishedByEightDays,
                    ["totalTaskCreatedByEightDays"] = totalTaskCreatedByEightDays,
                    ["totalTaskFinishedByEightDays"] = totalTaskFinishedByEightDays
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        private int getTotalTaskEstimatedToBeLate(List<Task> tasksOtherThanDone)
        {
            return tasksOtherThanDone.Where(
                task => task.ToDate > DateTime.Now && 
                task.FromDate.Value.AddDays(Math.Ceiling(task.Estimated ?? 0)) > task.ToDate
            ).Count();
        }


        private int getTotalTaskLate(List<Task> tasksOtherThanDone)
        {
            return tasksOtherThanDone.Where(task => task.ToDate < DateTime.Now)
                .Count();
        }

        private List<Dictionary<string, object>> getTotalTaskCreatedByEightDays(List<Task> tasks)
        {
            var result = new List<Dictionary<string, object>>();

            var now = DateTime.Now.Date;
            var eightDaysAgo = now.AddDays(-8);

            for (DateTime date = eightDaysAgo;
                date <= now.Date;
                date = date.AddDays(1))
            {
                result.Add(new Dictionary<string, object>
                {
                    ["Date"] = date,
                    ["TotalPoint"] = getTotalTaskCreatedByDate(tasks, date),
                });
            }

            return result;
        }

        private List<Dictionary<string, object>> getTotalTaskDoneByLastEightDays(List<Task> tasksDone)
        {
            var result = new List<Dictionary<string, object>>();

            var now = DateTime.Now.Date;
            var eightDaysAgo = now.AddDays(-8);

            for (DateTime date = eightDaysAgo;
                date <= now.Date;
                date = date.AddDays(1))
            {
                result.Add(new Dictionary<string, object>
                {
                    ["Date"] = date,
                    ["TotalPoint"] = getTotalTaskDoneByDate(tasksDone, date),
                });
            }

            return result;
        }

        private List<Dictionary<string, object>> getTotalPointByLastEightDays(List<Task> tasksDone)
        {
            var result = new List<Dictionary<string, object>>();

            var now = DateTime.Now.Date;
            var eightDaysAgo = now.AddDays(-8);

            for (DateTime date = eightDaysAgo;
                date <= now.Date;
                date = date.AddDays(1))
            {
                result.Add(new Dictionary<string, object>
                {
                    ["Date"] = date,
                    ["TotalPoint"] = getTotalPointsOfDate(tasksDone, date),
                }) ;
            }

            return result;
        }

        private int getTotalPointsOfDate(List<Task> tasksDone, DateTime date)
        {
            return tasksDone.Where(taskDone => taskDone.TaskHistories
                .Where(history => history.Action == TaskHistoryAction.MoveTask &&
                   history.ColumnName.ToLower().Equals("done")).FirstOrDefault()?.CreatedAt.Date == date)
                .Aggregate(0, (totalPoint, task) =>
                {
                    return totalPoint + (task.Point ?? 0);
                });
        }

        private int getTotalTaskCreatedByDate(List<Task> tasks, DateTime date)
        {
            return tasks.Where(task => task.CreatedAt.Date == date.Date)
                .Count();
        }

        private int getTotalTaskDoneByDate(List<Task> taskDones, DateTime date)
        {
            return taskDones.Where(taskDone => taskDone.TaskHistories
                 .Where(history => history.Action == TaskHistoryAction.MoveTask &&
                   history.ColumnName.ToLower().Equals("done")).FirstOrDefault()?.CreatedAt.Date == date)
                    .Count();
        }

        [HttpPost("/api/epic/link/{id}/{taskId}")]
        public IActionResult AddTaskToEpic(int id, int taskId)
        {
            try
            {
                _taskService.AddTaskToEpicTask(taskId, id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("/api/epic/task/{taskId}")]
        public IActionResult RemoveTaskFromEpic(int taskId)
        {
            try
            {
                _taskService.RemoveTaskFromEpic(taskId);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/board/{id}/orphan-task")]
        public IActionResult GetTasksThatDoesNotBelongToAnyEpic(int id)
        {
            try
            {
                var tasks = _taskService.GetTaskNotBelongToAnyEpic(id);

                var data = _mapper.Map<IEnumerable<TaskInfoDTO>>(tasks);
                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    ["data"] = data,
                    ["count"] = count,
                    ["total"] = total,
                });
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [AllowAnonymous]
        [HttpGet("/api/board/latetask/prediction")]
        public IActionResult GetPredictedLateTasks()
        {
            try
            {
                var predictions = _taskEstimationService.PredictLateTask(new TaskData
                {
                    TotalPoint = 8,
                    UserInChargeEfficiency = 1.12f,
                    UserReportToEfficiency = 1.25f,
                });

                return Ok(predictions);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("/api/epic/{id}/task")]
        public IActionResult GetTasksOfEpic(int id)
        {
            try
            {
                var tasks = _taskService.GetTasksOfEpic(id);

                var data = _mapper.Map<IEnumerable<TaskInfoDTO>>(tasks);
                var count = data.Count();
                var total = data.Count();

                return Ok(new Dictionary<string, object>
                {
                    ["data"] = data,
                    ["count"] = count,
                    ["total"] = total,
                });   
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
    }
}
