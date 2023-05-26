using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.EntityFrameworkCore;
using Models.DTO.Request;
using Models.Enums;
using Models.Models;
using Models.Repositories.DataContext;
using Task = Models.Models.Task;

namespace Services.Services
{
    public class TaskBoardService 
    {
        private readonly EmsContext _context;
        private readonly IMapper _mapper;
        private readonly IdentityService _identityService;
        public TaskBoardService(IMapper mapper, EmsContext context, IdentityService identityService)
        {
            _context = context;
            _mapper = mapper;
            _identityService = identityService;
        }

        public TaskColumn GetTaskColumnById(int id)
        {
            var taskColumn = _context.TaskColumns.Find(id);
            if (taskColumn == null)
            {
                throw new Exception("Task column not found");
            }

            return taskColumn;
        }
        public List<TaskBoard> GetTaskBoardListOfUser(int id)
        {
            var result = new List<TaskBoard>();

            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var team = _context.Teams.Find(user.TeamId);
            if (team == null)
            {
                throw new Exception("Team not found");
            }

            _context.Entry(team).Collection(t => t.TaskBoards).Load();

            if (team.TaskBoards == null)
            {
                return result;
            }

            foreach (var taskboard in team.TaskBoards)
            {
                _context.Entry(taskboard).Reference(b => b.Team).Load();
            }

            return team.TaskBoards;
        }

        public void CreateTaskBoard(TaskBoardDTO taskBoardDTO)
        {
            var user = _context.Users.Find(taskBoardDTO.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var team = _context.Teams.Find(user.TeamId);
            if (team == null)
            {
                throw new Exception("Team not found");
            }

            var taskBoard = _mapper.Map<TaskBoard>(taskBoardDTO);
            
            taskBoard.TeamId = team.Id;
            taskBoard.TaskColumns = new List<TaskColumn>();
            taskBoard.TaskColumns.AddRange(initDefaultTaskColumns());

            _context.TaskBoards.Add(taskBoard);
            _context.SaveChanges();
        }

        private List<TaskColumn> initDefaultTaskColumns()
        {
            return new List<TaskColumn>
            {
                new TaskColumn
                {
                    Name = "Todo",
                    Order = int.MinValue,
                },

                new TaskColumn
                {
                    Name = "Done",
                    Order = int.MaxValue - 1,
                },

                new TaskColumn
                {
                    Name = "Approved",
                    Order = int.MaxValue
                }
            };
        }

        public void UpdateTaskBoard(int id, TaskBoardDTO taskBoardDTO)
        {
            var taskBoard = _context.TaskBoards.Find(id);
            if (taskBoard == null)
            {
                throw new Exception("Cannot find task board");
            }

            var user = _context.Users.Find(taskBoardDTO.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var team = _context.Teams.Find(user.TeamId);
            if (team == null)
            {
                throw new Exception("Team not found");
            }

            taskBoard.Name = taskBoardDTO.Name;
            taskBoard.Description = taskBoardDTO.Description;
            taskBoard.TeamId = user.TeamId;

            _context.TaskBoards.Update(taskBoard);
            _context.SaveChanges();
        }

        public void DeleteTaskBoard(int id)
        {
            var taskBoard = _context.TaskBoards.Find(id);
            if (taskBoard == null)
            {
                throw new Exception("Task board is null");
            }

            loadColumnsAndTasksOfBoard(taskBoard);

            _context.TaskBoards.Remove(taskBoard);
            _context.SaveChanges();
        }

        public void CreateTaskColumn(TaskColumnDTO taskColumnDTO)
        {
            var taskBoard = _context.TaskBoards.Find(taskColumnDTO.TaskBoardId);
            if (taskBoard == null)
            {
                throw new Exception("Cannot find task board");
            }

            if (taskColumnDTO.Order == null)
            {
                throw new Exception("Required fields are missing");
            }

            var taskColumn = _mapper.Map<TaskColumn>(taskColumnDTO);

            taskColumn.BoardId = taskColumnDTO.TaskBoardId;
            
            _context.TaskColumns.Add(taskColumn);
            _context.SaveChanges();
        }

        public void DeleteTaskColumn(int taskColumnId)
        {
            var taskColumn = _context.TaskColumns.Find(taskColumnId);

            if (taskColumn == null)
            {
                throw new Exception("Task column not found");
            }

            _context.TaskColumns.Remove(taskColumn);
            _context.SaveChanges();
        }

        public void DeleteTaskLabel(int id)
        {
            var taskLabel = _context.TaskLabels.Find(id);
            if (taskLabel == null)
            {
                throw new Exception("Task label not found");
            }

            _context.TaskLabels.Remove(taskLabel);
            _context.SaveChanges();
        }

        public List<Task> GetTasksOfTaskColumn(int id,
            TaskFilterDTO taskFilterDTO)
        {
            var taskColumn = _context.TaskColumns
                .Where(column => column.Id == id)
                .Include(column => column.Tasks)
                .SingleOrDefault();

            if (taskColumn is null || taskColumn.Tasks == null)
            {
                return new List<Task>();
            }

            foreach (var task in taskColumn.Tasks)
            {
                _context.Entry(task).Reference(t => t.InCharge).Load();
                _context.Entry(task).Reference(t => t.ReportTo).Load();
                _context.Entry(task).Collection(t => t.Labels).Load();
            }

            var tasks = taskColumn.Tasks;

            if (!taskFilterDTO.IsDisabled)
            {
                if (taskFilterDTO.TaskType != null)
                {
                    if (taskFilterDTO.TaskType == "basic")
                    {
                        tasks = tasks.Where(task => task.Type == TaskType.BASIC).ToList();
                    }
                    else if (taskFilterDTO.TaskType == "epic")
                    {
                        tasks = tasks.Where(task => task.Type == TaskType.EPIC).ToList();
                    }
                }

                if (taskFilterDTO.InchargeIds != null && taskFilterDTO.InchargeIds.Count() > 0)
                {
                    tasks = tasks
                        .Where(task => task.InChargeId.HasValue ?
                            taskFilterDTO.InchargeIds.Contains(task.InChargeId.Value) : false)
                        .ToList();
                }

                if (taskFilterDTO.ReportToIds != null && taskFilterDTO.ReportToIds.Count() > 0)
                {
                    tasks = tasks
                        .Where(task => task.ReportToId.HasValue ?
                            taskFilterDTO.ReportToIds.Contains(task.ReportToId.Value) : false)
                        .ToList();
                }

                if (taskFilterDTO.LabelIds != null && taskFilterDTO.LabelIds.Count() > 0)
                {
                    tasks = tasks
                        .Where(task => task.Labels.Any(label => taskFilterDTO.LabelIds.Contains(label.Id)))
                        .ToList();
                }

                if (taskFilterDTO.StartDate != null)
                {
                    tasks = tasks
                        .Where(task => task.FromDate > taskFilterDTO.StartDate)
                        .ToList();
                }

                if (taskFilterDTO.EndDate != null)
                {
                    tasks = tasks
                        .Where(task => task.FromDate <= taskFilterDTO.EndDate)
                        .ToList();
                }

                if (taskFilterDTO.Options is not null)
                {
                    var lowercased = taskFilterDTO.Options.Select((option) =>  option.ToLower());

                    if (lowercased.Contains("islatetask"))
                    {
                        tasks = tasks.Where(task => DateTime.Now > task.ToDate) .ToList();
                    }

                    if (lowercased.Contains("isreopentask"))
                    {
                        tasks = tasks.Where(task => task.IsReopen is not null) .ToList();
                    }
                }
            }

            return tasks;
        }

        public List<User> GetUsersOfBoard(int boardId)
        {
            var board = _context.TaskBoards.Find(boardId);
            if (board == null)
            {
                throw new Exception("Board not found");
            }

            _context.Entry(board).Reference(b => b.Team).Load();
            
            var team = board.Team;
            if (team == null) {
                throw new Exception("Team not found");
            }

            _context.Entry(team).Collection(team => team.Members).Load();
            if (team.Members == null)
            {
                return new List<User>();
            }

            return team.Members;
        }

        public void UpdateTaskColumn(int id, TaskColumnDTO taskColumnDTO)
        {
            var taskColumn = _context.TaskColumns.Find(id);

            if (taskColumn == null)
            {
                throw new Exception("Task column not found");
            }

            taskColumn.Name = taskColumnDTO.Name;
            taskColumn.Description = taskColumnDTO.Description;
            taskColumn.Order = taskColumnDTO.Order;

            _context.TaskColumns.Update(taskColumn);
            _context.SaveChanges();
        }

        public TaskBoard GetTaskBoardById(int id)
        {
            var taskBoard = _context.TaskBoards.Find(id);
            if (taskBoard == null)
            {
                throw new Exception("Task board is null");
            }

            loadColumnsAndTasksOfBoard(taskBoard);

            return taskBoard;
        }

        public List<TaskColumn> GetTaskColumnsOfBoard(int id)
        {
            var taskboard = _context.TaskBoards.Find(id);
            if (taskboard == null)
            {
                throw new Exception("");
            }

            _context.Entry(taskboard)
                .Collection(tb => tb.TaskColumns).Load();

            if (taskboard.TaskColumns == null)
            {
                throw new Exception("");
            }


            foreach (var column in taskboard.TaskColumns)
            {
                _context.Entry(column).Reference(r => r.Board).Load();
            }


            return taskboard.TaskColumns
                .OrderBy(column => column.Order)
                .ToList();
        }

        public List<TaskLabel> GetTaskLabelsOfBoard(int id)
        {
            var taskboard = _context.TaskBoards.Find(id);
            if (taskboard == null)
            {
                throw new Exception("");
            }

            _context.Entry(taskboard)
                .Collection(tb => tb.TaskLabels).Load();

            if (taskboard.TaskLabels == null)
            {
                throw new Exception("");
            }

            foreach (var label in taskboard.TaskLabels)
            {
                _context.Entry(label).Reference(r => r.TaskBoard).Load();
            }

            return taskboard.TaskLabels;
        }

        public TaskLabel GetTaskLabelById(int id)
        {
            var tasklabel = _context.TaskLabels.Find(id);
            if (tasklabel == null)
            {
                throw new Exception("Task label not found");
            }

            return tasklabel;
        }

        public void CreateTaskLabel(TaskLabelDTO taskLabelDTO)
        {
            var taskBoard = _context.TaskBoards.Find(taskLabelDTO.TaskBoardId);
            if (taskBoard == null)
            {
                throw new Exception("");
            }

            var taskLabel = _mapper.Map<TaskLabel>(taskLabelDTO);

            _context.TaskLabels.Add(taskLabel);
            _context.SaveChanges();
        }

        public void UpdateTaskLabel(int id, TaskLabelDTO taskLabelDTO)
        {
            var taskLabel = _context.TaskLabels.Find(id);
            if (taskLabel == null)
            {
                throw new Exception("task label is null");
            }

            taskLabel.Name = taskLabelDTO.Name;
            taskLabel.Description = taskLabelDTO.Description;

            _context.TaskLabels.Update(taskLabel);
            _context.SaveChanges();
        }

        private void loadColumnsAndTasksOfBoard(TaskBoard taskBoard)
        {
            _context.Entry(taskBoard)
                .Collection(tb => tb.TaskColumns)
                .Load();

            _context.Entry(taskBoard)
                .Collection(tb => tb.TaskLabels)
                .Load();

            _context.Entry(taskBoard)
                .Reference(tb => tb.Team)
                .Load();

            foreach (var taskColumn in taskBoard.TaskColumns)
            {
                _context.Entry(taskColumn)
                    .Collection(tc => tc.Tasks)
                    .Load();
            }
        }
    }
}
