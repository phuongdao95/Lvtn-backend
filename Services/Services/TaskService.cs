using AutoMapper;
using Models.DTO.Request;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;
using Task = Models.Models.Task;

namespace Services.Services
{
    public class TaskService : ITaskService
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

            loadTaskLabelsAndTaskCommentsOfTask(task);

            return task;
        }

        public void CreateTask(TaskDTO taskDTO)
        {
            var taskColumn = _context.TaskColumns.Find(taskDTO.ColumnId);
            if (taskColumn == null)
            {
                throw new Exception("Task Column should not be null");
            }

            var task = _mapper.Map<Task>(taskDTO);
            task.ColumnId = taskDTO.ColumnId;
            task.EmployeeId = taskDTO.EmployeeId;

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
            task.EmployeeId = taskDTO.EmployeeId;
            task.ColumnId = taskDTO.ColumnId;
            task.Deadline = taskDTO.Deadline;

            _context.Tasks.Update(task);
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
