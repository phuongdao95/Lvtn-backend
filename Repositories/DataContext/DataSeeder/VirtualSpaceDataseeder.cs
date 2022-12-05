using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using System.Reflection.Emit;
using Task = Models.Models.Task;

namespace Repositories.DataContext.DataSeeder
{
    public class VirtualSpaceDataseeder : DataSeeder
    {
        private static readonly List<string> _taskBoardNames = new List<string>
        {
            "Board Alpha",
            "Board Beta",
            "Board Gamma",
            "Board Sigma"
        };

        private static readonly List<string> _taskColumnNames = new List<string>
        {
            "Todo",
            "Waiting",
            "Doing",
            "Done",
        };

        private static readonly List<string> _taskLabelNames = new List<string>
        {
            "Label 1",
            "Label 2",
            "Label 3",
            "Label 4"
        };


        private readonly List<Team> _teams;

        private readonly List<TaskBoard> _taskBoards;
        private readonly List<TaskColumn> _taskColumns;
        private readonly List<TaskLabel> _taskLabels;
        private readonly List<Task> _tasks;

        private readonly ModelBuilder _modelBuilder;
        public VirtualSpaceDataseeder(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
            _teams = initializeTeams();
            _taskBoards = initializeTaskBoards();
            _taskColumns = initializeTaskColumns();
            _taskLabels = initializeTaskLabels();
            _tasks = initializeTasks();
        }

        private List<Team> initializeTeams()
        {
            return new AdministrationDataSeeder(_modelBuilder).Teams;
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
                int order = 0;
                result.AddRange(_taskColumnNames.Select(name =>
                {
                    return new TaskColumn
                    {
                        Id = ++index,
                        Name = name,
                        Order = name == "Todo" ? int.MinValue : name == "Done" ? int.MaxValue : ++order,
                        Description = name,
                        BoardId = board.Id,
                    };
                }
                ));
            }

            return result;
        }

        private List<TaskLabel> initializeTaskLabels()
        {
            var result = new List<TaskLabel>();
            var index = 0;

            foreach (var taskBoard in _taskBoards)
            {
                result.AddRange(_taskLabelNames.Select(name => new TaskLabel()
                {
                    Id = ++index,
                    Name = name,
                    Description = name,
                    TaskBoardId = taskBoard.Id
                }));
            }

            return result;
        }

        private List<Task> initializeTasks()
        {
            var result = new List<Task>();
            var count = 2;
            int index = 0;

            foreach (var taskColumn in _taskColumns)
            {
                int order = 0;
                result.AddRange(Enumerable.Range(0, count).Select(i => new Task
                {
                    Id = ++index,
                    ColumnId = taskColumn.Id,
                    Order = ++order, 
                    FromDate = new DateTime(2022, 10, 12),
                    ToDate = new DateTime(2022, 10, 17),
                    Point = new Random().Next(5, 20),
                    Name = $"Item {index}",
                }));
            }

            return result;
        }

        public void SeedData()
        {
            _modelBuilder.Entity<TaskBoard>()
                .HasData(_taskBoards);

            _modelBuilder.Entity<TaskColumn>()
                .HasData(_taskColumns);

            _modelBuilder.Entity<TaskLabel>()
                .HasData(_taskLabels);

            _modelBuilder.Entity<Task>()
                .HasData(_tasks);
        }

    }
}
