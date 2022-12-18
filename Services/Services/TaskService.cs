using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.DTO.Request;
using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using Task = Models.Models.Task;

namespace Services.Services
{
    public class TaskService
    {
        private readonly IMapper _mapper;
        private readonly EmsContext _context;
        private readonly TaskHistoryService _taskHistoryService;

        public TaskService(
            IMapper mapper, 
            EmsContext context, 
            TaskHistoryService taskHistoryService)
        {
            _mapper = mapper;
            _context = context;
            _taskHistoryService = taskHistoryService;
        }

        public Task GetTaskById(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                throw new Exception("Task cannot be null");
            }


            var column = _context.TaskColumns.Find(task.ColumnId);
            if (column == null)
            {
                throw new Exception("Column not found");
            }
            var inCharge = _context.Users.Find(task.InChargeId);
            var reportTo = _context.Users.Find(task.ReportToId);

            if (task.InChargeId != null && inCharge == null)
            {
                throw new Exception("User not found");
            }

            if (task.ReportTo != null && reportTo == null)
            {
                throw new Exception("User not found");
            }

            task.InCharge = inCharge;
            task.ReportTo = reportTo;
            task.Column = column;

            return task;
        }

        public void AddTaskLabel(int taskId, int taskLabelId)
        {
            var task = _context.Tasks.Where(task => task.Id == taskId)
                .Include(task => task.Labels)
                .Single();

            var taskLabel = _context.TaskLabels.Find(taskLabelId);

            if (task == null || task.Labels == null)
            {
                throw new Exception("Task not init properly");
            }

            if (taskLabel == null)
            {
                throw new Exception("Task label not found");
            }

            task.Labels.Add(taskLabel);
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void RemoveTaskLabelFromTask(int taskId, int taskLabelId)
        {
            var task = _context.Tasks.Where(task => task.Id == taskId)
                .Include(task => task.Labels)
                .Single();

            var taskLabel = _context.TaskLabels.Find(taskLabelId);

            if (task == null || task.Labels == null)
            {
                throw new Exception("Task not init properly");
            }

            if (taskLabel == null)
            {
                throw new Exception("Task label not found");
            }

            task.Labels = task.Labels.Where(label => label.Id != taskLabelId).ToList();

            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void CreateTask(TaskDTO taskDTO)
        {
            var taskColumn = _context.TaskColumns.Find(taskDTO.ColumnId);
            if (taskColumn == null)
            {
                throw new Exception("Task column not found");
            }

            var task = _mapper.Map<Task>(taskDTO);
            task.ColumnId = taskDTO.ColumnId;
            task.InChargeId = taskDTO.InChargeId;
            task.ReportToId = taskDTO.ReportToId;
            task.Type = getTaskTypeFromText(taskDTO.TaskType);

            _context.Tasks.Add(task);
            _context.SaveChanges();

            var taskHistory = _taskHistoryService.BuildTaskHistoryFromTaskFieldsAndTaskId(task.Id, TaskHistoryAction.CreateTask);

            if (task.TaskHistories == null)
            {
                task.TaskHistories = new List<TaskHistory> { taskHistory };
            }

            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        private TaskType getTaskTypeFromText(string text)
        {
            switch (text)
            {
                case "normal":
                    return TaskType.BASIC;
                case "epic":
                    return TaskType.EPIC;
            }

            return TaskType.BASIC;
        }

        public void DeleteTask(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                throw new Exception("Cannot delete task of null");
            }

            loadTaskLabelsAndTaskCommentsOfTask(task);
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }

        public void UpdateTask(int id, TaskDTO taskDTO)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                throw new Exception("Task cannot be null");
            }

            task.Name = taskDTO.Name;
            task.InChargeId = taskDTO.InChargeId;
            task.ReportToId = taskDTO.ReportToId;
            task.ColumnId = taskDTO.ColumnId;
            task.Point = taskDTO.Point;
            task.FromDate = taskDTO.FromDate;
            task.ToDate = taskDTO.ToDate;

            _context.Tasks.Update(task);
            _context.SaveChanges();

            var taskHistory = _taskHistoryService.BuildTaskHistoryFromTaskFieldsAndTaskId(id, TaskHistoryAction.CreateTask);

            _context.Entry(task)
                .Collection(t => t.TaskHistories)
                .Load();

            taskHistory.Action = TaskHistoryAction.UpdateFields;

            if (task.TaskHistories == null)
            {
                throw new Exception("Task History not found");
            }

            task.TaskHistories.Add(taskHistory);

            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public List<TaskLabel> GetTaskLabelsOfTask(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            if (task == null)
            {
                throw new Exception("Task not found");
            }

            _context.Entry(task).Collection(t => t.Labels).Load();

            if (task.Labels == null)
            {
                return new List<TaskLabel>();
            }

            return task.Labels;
        }

        public List<TaskComment> GetTaskComments(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            if (task == null)
            {
                throw new Exception("Task not found");
            }

            _context.Entry(task).Collection(t => t.Comments).Load();


            if (task.Comments == null)
            {
                return new List<TaskComment>();
            }

            foreach (var comment in task.Comments)
            {
                _context.Entry(comment).Reference(c => c.User).Load();
            }

            return task.Comments;
        }

        public List<TaskFile> GetTaskFiles(int taskId) 
        {
            var task = _context.Tasks.Find(taskId);
            if (task == null)
            {
                throw new Exception("Task not found");
            }

            _context.Entry(task).Collection(t => t.Files).Load();

            if (task.Files == null)
            {
                return new List<TaskFile>();
            }


            return task.Files;
        }

        public TaskFile GetTaskFileById(int fileId)
        {
            var file = _context.TaskFiles.Find(fileId);
            if (file == null)
            {
                throw new Exception();
            }

            return file;
        }

        public void CreateSubTaskOfTask(int taskId, TaskDTO taskDTO)
        {
            var task = _context.Tasks.Where(task => task.Id == taskId)
                .Include(task => task.SubTasks)
                .Single();

            if (task == null ||
                task.SubTasks == null)
            {
                throw new Exception("task and its subtasks should not be null");
            }

            var subTask = _mapper.Map<Task>(taskDTO);

            task.SubTasks.Add(subTask);

            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public List<Task> GetSubtasksOfTask(int taskId)
        {
            var task = _context.Tasks.Where(task => task.Id == taskId)
                .Include(task => task.SubTasks)
                .Single();

            if (task.SubTasks == null)
            {
                throw new Exception("Task not found");
            }

            return task.SubTasks;
        }

        public void UpdateDescription(int taskId, string description)
        {
            var task = _context.Tasks.Find(taskId);
            if (task == null)
            {
                throw new Exception("Task not found");
            }

            _context.Entry(task)
                .Collection(t => t.TaskHistories)
                .Load();

            task.Description = description;

            _context.Tasks.Update(task);
            _context.SaveChanges();

            var taskHistory = _taskHistoryService.BuildTaskHistoryFromTaskFieldsAndTaskId(
                taskId, TaskHistoryAction.UpdateDescription);

            if (task.TaskHistories == null)
            {
                throw new Exception();
            }

            task.TaskHistories.Add(taskHistory);
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public List<Task> GetTaskNotBelongToAnyEpic(int boardId)
        {
            var board = _context.TaskBoards
                .Include(board => board.TaskColumns)
                .Where(board => board.Id == boardId)
                .FirstOrDefault();

            if (board == null || board.TaskColumns == null)
            {
                throw new Exception("Board id null");
            }

            var boardColumnIds = board.TaskColumns.Select(c => c.Id).ToList();
            var tasks = _context.Tasks
                .Where(task => task.Type == TaskType.BASIC)
                .Where(task => task.ParentTaskId == null)
                .Where(task => boardColumnIds.Contains(task.ColumnId.Value))
                .ToList();

            return tasks;
        }

        public List<Task> GetTasksOfEpic(int epicId)
        {
            var epic = _context.Tasks
                .Include(epic => epic.SubTasks)
                .Where(task => task.Id == epicId)
                .FirstOrDefault();

            if (epic == null || epic.Type != TaskType.EPIC || epic.SubTasks == null)
            {
                throw new Exception("Invalid epicId");
            }

            foreach (var task in epic.SubTasks)
            {
                _context.Entry(task).Reference(t => t.ReportTo);
                _context.Entry(task).Reference(t => t.InCharge);
            }

            return epic.SubTasks ?? new List<Task>();
        }

        public void AddTaskToEpicTask(int taskId, int epicId)
        {
            var epic = _context.Tasks
                .Include(epic => epic.SubTasks)
                .Where(epic => epic.Id == epicId)
                .FirstOrDefault();

            var task = _context.Tasks.Find(taskId);

            if (epic == null || epic.SubTasks == null || task == null)
            {
                throw new Exception("Invalid taskId or epic id");
            }

            if (epic.Type != TaskType.EPIC && task.Type != TaskType.BASIC)
            {
                throw new Exception("Invalid epicId or taksId");
            }

            epic.SubTasks.Add(task);

            _context.Tasks.Update(epic);
            _context.SaveChanges();
        }

        public void RemoveTaskFromEpic(int taskId)
        {
            var task = _context.Tasks
                .Include(task => task.ParentTask)
                .Where(task => task.Id == taskId)
                .Where(task => task.Type == TaskType.BASIC)
                .FirstOrDefault();

            if (task == null)
            {
                throw new Exception("task not found");
            }

            task.ParentTaskId = null;

            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void MoveTask(int taskId, MoveTaskDTO moveTaskDTO)
        {
            var task = _context.Tasks.Find(taskId);
            if (task == null)
            {
                throw new Exception("Task not found");
            }

            var taskBoard = _context.TaskBoards.Find(moveTaskDTO.TaskBoardId);
            if (taskBoard == null)
            {
                throw new Exception("Task board is null");
            }
            _context.Entry(taskBoard).Collection(tb => tb.TaskColumns).Load();
            _context.Entry(task).Collection(t => t.TaskHistories).Load();

            if (taskBoard.TaskColumns == null)
            {
                throw new Exception();
            }

            var srcColumn = taskBoard.TaskColumns.Where(t => t.Name == moveTaskDTO.sourceColumnName).Single();
            var destColumn = taskBoard.TaskColumns.Where(t => t.Name == moveTaskDTO.destinationColumnName).Single();

            task.ColumnId = destColumn.Id;

            _context.Tasks.Update(task);
            _context.SaveChanges();

            if (task.TaskHistories == null)
            {
                throw new Exception("Task not init properly");
            }
            var taskHistory = _taskHistoryService.BuildTaskHistoryFromTaskFieldsAndTaskId(
                taskId, TaskHistoryAction.MoveTask);
            task.TaskHistories.Add(taskHistory);
            _context.SaveChanges();
        }

        public void AddTaskComment(int taskId, TaskCommentDTO taskCommentDTO)
        {
            var task = _context.Tasks.Find(taskId);
            if (task == null)
            {
                throw new Exception("Task not found");
            }

            var taskComment = _mapper.Map<TaskComment>(taskCommentDTO);

            taskComment.CreatedAt = DateTime.Now;
            _context.Entry(task).Collection(t => t.Comments).Load();

            task.Comments.Add(taskComment);

            _context.Tasks.Update(task);
            _context.SaveChanges();

            _context.Entry(task).Collection(t => t.TaskHistories).Load();

            var taskHistory = _taskHistoryService.BuildTaskHistoryFromTaskCommentAndTaskId(
                taskId, taskComment, TaskHistoryAction.AddComment);

            taskHistory.Action = TaskHistoryAction.AddComment;

            if (task.TaskHistories == null)
            {
                throw new Exception();
            }

            task.TaskHistories.Add(taskHistory);
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void RemoveTaskComment(int commentId)
        {
            var taskComment = _context.TaskComments.Find(commentId);
            if (taskComment == null)
            {
                throw new Exception("Task comment not found");
            }

            _context.TaskComments.Remove(taskComment);
            _context.SaveChanges();
        }

        private void loadTaskLabelsAndTaskCommentsOfTask(Task task)
        {
            _context.Entry(task)
                .Collection(t => t.Labels)
                .Load();

            _context.Entry(task)
                .Collection(t => t.Comments)
                .Load();

            _context.Entry(task)
                .Collection(t => t.SubTasks)
                .Load();
        }
    }
}
