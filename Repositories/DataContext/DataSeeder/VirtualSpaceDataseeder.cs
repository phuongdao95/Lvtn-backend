using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Task = Models.Models.Task;

namespace Repositories.DataContext.DataSeeder
{
    public class VirtualSpaceDataseeder : DataSeeder
    {
        private static readonly List<string> _taskBoardNames = new List<string>
        {
            "Board 1",
            "Board 2",
        };

        private static readonly List<string> _taskColumnNames = new List<string>
        {
            "Column 1",
            "Column 2",
            "Column 3",
            "Column 4",
        };

        private readonly List<Team> _teams;

        private readonly List<Task> _tasks;
        private readonly List<TaskBoard> _taskBoards;
        private readonly List<TaskColumn> _taskColumns;
        private readonly List<TaskComment> _taskComments;
        private readonly List<TaskLabel> _taskLabels;

        private readonly ModelBuilder _modelBuilder;
        public VirtualSpaceDataseeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
            _teams = AdministrationDataSeeder.DefaultTeamMap.Values.ToList();
            _taskBoards = initializeTaskBoards();
            _taskColumns = initializeTaskColumns();
            _taskComments = initializeTaskComments();
            _taskLabels = initializeTaskLabels();
            _modelBuilder = modelBuilder;

        }

        private List<TaskBoard> initializeTaskBoards()
        {
            var result = new List<TaskBoard>();
            var index = 0;

            foreach (var team in _teams)
            {
                result.AddRange(_taskBoardNames.Select(name => new TaskBoard
                {
                    Id = ++index,
                    Name = name,
                    Description = name,
                    TeamId = team.Id,
                })); ;
            }

            return result;
        }

        private List<TaskColumn> initializeTaskColumns()
        {
            var result = new List<TaskColumn>();
            var index = 0;

            foreach (var board in _taskBoards)
            {
                result.AddRange(_taskBoardNames.Select(name =>  new TaskColumn
                {
                    Id= ++index,
                    Name= name,
                    BoardId = board.Id,
                }));
            }

            return result;
        }

        private List<Task> initializeTask()
        {
            var result = new List<Task>();


            return result;
        }

        private List<TaskComment> initializeTaskComments()
        {
            var result = new List<TaskComment>();
            return result;
        }

        private List<TaskLabel> initializeTaskLabels()
        {
            var result = new List<TaskLabel>();
            return result;
        }

        private List<Dictionary<string, object>> initializeTaskTaskLabel()
        {
            var result = new List<Dictionary<string, object>>();
            return result;
        }

        public void SeedData()
        {
            throw new NotImplementedException();
        }

    }
}
