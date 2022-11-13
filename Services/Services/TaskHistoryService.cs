using Microsoft.EntityFrameworkCore;
using Models.DTO.Response;
using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using Task = Models.Models.Task;

namespace Services.Services
{
    public class TaskHistoryService
    {
        private readonly EmsContext _context;
        private readonly IdentityService _identityService;
        public TaskHistoryService(EmsContext context, IdentityService identityService)
        {
            _context = context;
            _identityService = identityService;
        }

        public List<TaskHistoryDTO> GetTaskHistoriesOfTask(int taskId)
        {
            var task = _context.Tasks.Where(task => task.Id == taskId)
                .Include(task => task.TaskHistories)
                .Single();

            if (task == null || task.TaskHistories == null)
            {
                throw new Exception("TaskHistory not init properly");
            }

            foreach (var taskHistory in task.TaskHistories)
            {
                _context.Entry(taskHistory).Reference(th => th.TaskLabelHistory).Load();
                _context.Entry(taskHistory).Reference(th => th.TaskCommentHistory).Load();
                _context.Entry(taskHistory).Reference(th => th.TaskFileHistory).Load();
            }

            var result = new List<TaskHistoryDTO>();
            var index = 0;
            foreach (var taskHistory in task.TaskHistories)
            {
                var taskHistoryDTO = buildDTOFromTaskHistory(taskHistory);
                taskHistoryDTO.Id = ++index;
                result.Add(taskHistoryDTO);
            }

            return result;
        }

        private TaskHistoryDTO buildDTOFromTaskHistory(TaskHistory taskHistory)
        {
            var name = _identityService.GetCurrentUserName();
            var taskFile = taskHistory.TaskFileHistory;
            var taskComment = taskHistory.TaskCommentHistory;
            var taskLabel = taskHistory.TaskLabelHistory;

            if (taskHistory.Action == TaskHistoryAction.DeleteFile)
            {
                return new TaskHistoryDTO
                {
                    UserId = taskHistory.UpdatedById,
                    Action = "deletefile",
                    DateTime = taskHistory.UpdatedAt,
                    TaskFileHistoryId = taskFile.TaskFileId,
                    Message = $"{name} đã xóa file {taskFile.DisplayFileName}",
                };
            }
            else if (taskHistory.Action == TaskHistoryAction.AddFile)
            {
                return new TaskHistoryDTO
                {
                    UserId = taskHistory.CreatedById,
                    Action = "addfile",
                    DateTime = taskHistory.CreatedAt,
                    TaskFileHistoryId = taskFile.TaskFileId,
                    Message = $"{name} đã thêm file {taskFile.DisplayFileName}",
                };

            }
            else if (taskHistory.Action == TaskHistoryAction.UpdateFile)
            {
                return new TaskHistoryDTO
                {
                    UserId = taskHistory.UpdatedById,
                    Action = "updatefile",
                    DateTime = DateTime.Now,
                    TaskFileHistoryId = taskFile.TaskFileId,
                    Message = $"{name} đã cập nhật file {taskFile.DisplayFileName}",
                };
            }
            else if (taskHistory.Action == TaskHistoryAction.UpdateDescription)
            {
                return new TaskHistoryDTO
                {
                    UserId = taskHistory.UpdatedById,
                    Action = "updatedescription",
                    DateTime = taskHistory.UpdatedAt,
                    TaskHistoryId = taskHistory.Id,
                    Message = $"{name} đã cập nhật mô tả",
                };
            }
            else if (taskHistory.Action == TaskHistoryAction.AddComment)
            {
                return new TaskHistoryDTO
                {
                    UserId = taskHistory.CreatedById,
                    Action = "addcomment",
                    DateTime= taskHistory.CreatedAt,
                    TaskCommentHistoryId = taskComment.Id,
                    Message = $"{name} đã thêm một comment"
                };
            }
            else if (taskHistory.Action == TaskHistoryAction.AddLabel)
            {
                return new TaskHistoryDTO
                {
                    UserId = taskHistory.UpdatedById,
                    DateTime = taskHistory.UpdatedAt,
                    Action = "addlabel",
                    TaskLabelHistoryId = taskLabel.Id,
                    Message = $"{name} đã thêm nhãn {taskLabel.Name}"
                };
            }
            else if (taskHistory.Action == TaskHistoryAction.MoveTask)
            {
                return new TaskHistoryDTO
                {
                    UserId = taskHistory.UpdatedById,
                    DateTime = taskHistory.UpdatedAt,
                    Action = "movetask",
                    TaskHistoryId = taskHistory.Id,
                    Message = $"{name} đã chuyển trạng thái sang {taskHistory.ColumnName}"
                };
            }
            else if (taskHistory.Action == TaskHistoryAction.UpdateFields)
            {
                return new TaskHistoryDTO
                {
                    UserId = taskHistory.UpdatedById,
                    DateTime = taskHistory.UpdatedAt,
                    Action = "updatefields",
                    TaskHistoryId = taskHistory.Id,
                    Message = $"{name} đã chuyển cập nhật fields của task"
                };
            }
            else
            {
                return new TaskHistoryDTO
                {

                };
            }
        }


        public TaskHistory BuildTaskHistoryFromTaskFileAndTaskId(int taskId, TaskFile taskFile, TaskHistoryAction action)
        {
            if (!(action == TaskHistoryAction.AddFile ||
                action == TaskHistoryAction.UpdateFile ||
                action == TaskHistoryAction.DeleteFile))
            {
                throw new Exception("Action not related to file");
            }

            var task = _context.Tasks.Find(taskId);
            if (task == null)
            {
                throw new Exception("TaskId is not valid");
            }

            var taskFileHistory = new TaskFileHistory
            {
                TaskFileId = taskFile.Id,
                Description = taskFile.Description,
                DisplayFileName = taskFile.DisplayFileName,
            };

            return new TaskHistory
            {
                TaskFileHistory = taskFileHistory,
                Action = action,
                TaskId = taskId,
            };
        }

        public TaskHistory BuildTaskHistoryFromTaskCommentAndTaskId(int taskId, TaskComment taskComment, TaskHistoryAction action)
        {
            if (taskComment.User == null)
            {
                throw new Exception("Task comment not init properly");
            }

            if (action != TaskHistoryAction.AddComment)
            {
                throw new Exception("Action not related to comment");
            }

            var task = _context.Tasks.Find(taskId);
            if (task == null)
            {
                throw new Exception("TaskId is not valid");
            }

            var taskCommentHistory = new TaskCommentHistory
            {
                TaskCommentId = taskComment.Id,
                UserName = taskComment.User.Name,
                Message = taskComment.Message,
            };

            return new TaskHistory
            {
                Action = action,
                TaskCommentHistory = taskCommentHistory,
                TaskId = taskId
            };
        }

        public TaskHistory BuildTaskHistoryFromTaskLabelAndTaskId(int taskId, TaskLabel taskLabel, TaskHistoryAction aciton)
        {
            if (aciton != TaskHistoryAction.AddLabel ||
                aciton != TaskHistoryAction.DeleteLabel)
            {
                throw new Exception("Invalid action");
            }

            var task = _context.Tasks.Find(taskId);
            if (task == null)
            {
                throw new Exception("Task not found");
            }

            var taskLabelHistory = new TaskLabelHistory
            {
                Name = taskLabel.Name,
                Description = taskLabel.Description,
            };

            return new TaskHistory
            {
                TaskId = taskId,
                TaskLabelHistory = taskLabelHistory,
                Action = aciton,
            };
        }

        public TaskHistory BuildTaskHistoryFromTaskFieldsAndTaskId(int taskId, TaskHistoryAction action)
        {
            var task = _context.Tasks.Where(t => t.Id == taskId)
                .Include(t => t.InCharge)
                .Include(t => t.ReportTo)
                .Include(t => t.Column)
                .Single();

            if (task == null)
            {
                throw new Exception("TaskId is not valid");
            }

            var taskHistory = new TaskHistory();

            taskHistory.TaskId = taskId;
            taskHistory.Action = action;

            if (action == TaskHistoryAction.MoveTask)
            {
                var column = _context.TaskColumns.Find(task.ColumnId);

                taskHistory.ColumnId = task.ColumnId;
                taskHistory.ColumnName = column.Name;
            }
            else if (action == TaskHistoryAction.CreateTask || action == TaskHistoryAction.UpdateFields)
            {
                taskHistory.InChargeId = task.InChargeId;
                taskHistory.InChargeName = task.InCharge?.Name;
                taskHistory.ReportToId = task.ReportToId;
                taskHistory.ReportToName = task.InCharge?.Name;
                taskHistory.Description = task.Description;
            }
            else if (action == TaskHistoryAction.UpdateDescription)
            {
                taskHistory.Description = task.Description;
            }
            else
            {
                throw new Exception("Invalid action");
            }

            return taskHistory;
        }

    }
}
