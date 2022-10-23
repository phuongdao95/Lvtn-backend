using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.DTO.Request;
using Models.Models;
using Models.Repositories.DataContext;
using Task = Models.Models.Task;

namespace Services.Services
{
    public class TaskService
    {
        private readonly IMapper _mapper;
        private readonly EmsContext _context;

        public TaskService(IMapper mapper, EmsContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task GetTaskById(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
            {
                throw new Exception("Task cannot be null");
            }

            _context.Entry(task).Reference(t => t.InCharge).Load();
            _context.Entry(task).Reference(t => t.ReportTo).Load();

            var column = _context.TaskColumns.Find(task.ColumnId);
            if (column == null)
            {
                throw new Exception("Column not found");
            }

            task.Column = column;

            return task;
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

            if (taskDTO.TaskLabelIds != null)
            {
                var labels = _context.TaskLabels.Where(taskLabel => taskDTO.TaskLabelIds.Contains(taskLabel.Id)).ToList();

                task.Labels = labels;

            }

            _context.Tasks.Add(task);
            _context.SaveChanges();
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
            task.Description = taskDTO.Description;
            task.Point = taskDTO.Point;
            task.FromDate = taskDTO.FromDate;
            task.ToDate = taskDTO.ToDate;

            if (taskDTO.TaskLabelIds != null)
            {
                var labels = _context.TaskLabels.Where(taskLabel => taskDTO.TaskLabelIds.Contains(taskLabel.Id)).ToList();

                task.Labels = labels;
            }

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

        public void UpdateDescription(int taskId, string description)
        {
            var task = _context.Tasks.Find(taskId);
            if (task == null)
            {
                throw new Exception("Task not found");
            }

            task.Description = description;

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

            if (taskBoard.TaskColumns == null)
            {
                throw new Exception();
            }

            var srcColumn = taskBoard.TaskColumns.Where(t => t.Name == moveTaskDTO.sourceColumnName).Single();
            var destColumn = taskBoard.TaskColumns.Where(t => t.Name == moveTaskDTO.destinationColumnName).Single();

            task.ColumnId = destColumn.Id;

            _context.Tasks.Update(task);
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

            _context.Entry(task).Collection(t => t.Comments).Load();

            task.Comments.Add(taskComment);

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
        }
    }
}
