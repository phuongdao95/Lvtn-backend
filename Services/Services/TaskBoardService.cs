using AutoMapper;
using Models.DTO.Request;
using Models.Models;
using Models.Repositories.DataContext;
using Services.Contracts;

namespace Services.Services
{
    public class TaskBoardService : ITaskBoardService
    {
        private readonly EmsContext _context;
        private readonly IMapper _mapper;
        public TaskBoardService(IMapper mapper, EmsContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public void CreateTaskBoard(TaskBoardDTO taskBoardDTO)
        {
            var team = _context.Teams.Find(taskBoardDTO.TeamId);
            if (team == null)
            {
                throw new Exception("Cannot find the team");
            }

            var taskBoard = _mapper.Map<TaskBoard>(taskBoardDTO);
            taskBoard.TeamId = taskBoard.TeamId;

            _context.TaskBoards.Add(taskBoard);
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

            var taskColumn = _mapper.Map<TaskColumn>(taskColumnDTO);

            taskColumn.BoardId = taskColumnDTO.TaskBoardId;
            _context.TaskColumns.Add(taskColumn);
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

        private void loadColumnsAndTasksOfBoard(TaskBoard taskBoard)
        {
            _context.Entry(taskBoard)
             .Collection(tb => tb.TaskColumns)
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
