using Models.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.DataContext.DataSeeder;
using Task = Models.Models.Task;
using Microsoft.Extensions.DependencyInjection;

namespace Models.Repositories.DataContext
{
    public class EmsContext : DbContext
    {
        public DbSet<Notification> Notifications { get; set; }
        /** Administration Module */
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Group> Groups { get; set; }

        /** Salary Management */
        public DbSet<SalaryGroup> SalaryGroups { get; set; }
        public DbSet<SalaryDelta> SalaryDeltas { get; set; }
        public DbSet<SalaryFormula> SalaryFormulas { get; set; }
        public DbSet<SalaryVariable> SalaryVariables { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Payslip> Payslips { get; set; }

        /** Timekeeping */
        public DbSet<WorkingShiftEvent> WorkingShiftEvents { get; set; }
        public DbSet<WorkingShiftTimekeeping> WorkingShiftTimekeepings { get; set; }

        /** Virtual Space */
        public DbSet<TaskBoard> TaskBoards { get; set; }
        public DbSet<TaskColumn> TaskColumns { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }
        public DbSet<TaskFile> TaskFiles { get; set; }
        public DbSet<TaskLabel> TaskLabels { get; set; }
        
        public EmsContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            /** Administration Mappings*/
            // 1-M User-Role
            modelBuilder.Entity<User>()
                .HasOne(p => p.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // M-N Role Permission
            modelBuilder.Entity<Role>()
                .HasMany(p => p.Permissions)
                .WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "RolePermission",
                    right => right.HasOne<Permission>().WithMany().HasForeignKey("PermissionId"),
                    left => left.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                    je => je.HasKey("PermissionId", "RoleId")
                );

            modelBuilder.Entity<User>()
                .HasIndex(p => p.Username)
                .IsUnique();

            // 1-1 Team-User (1 Team managed by one User)
            modelBuilder.Entity<User>()
                .HasOne(u => u.TeamManage)
                .WithOne(t => t.Leader)
                .HasForeignKey<Team>(t => t.LeaderId);

            // 1-M Team-User (many Users belong to 1 Team)
            modelBuilder.Entity<User>()
                .HasOne(u => u.Team)
                .WithMany(t => t.Members)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // 1-1 User-BankInfo
            modelBuilder.Entity<User>()
                .HasOne(u => u.BankInfo)
                .WithOne()
                .HasForeignKey<User>(u => u.BankInfoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Groups)
                .WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserGroup",
                    left => left.HasOne<Group>().WithMany().HasForeignKey("GroupId"),
                    right => right.HasOne<User>().WithMany().HasForeignKey("UserId"),
                    je => je.HasKey("GroupId", "UserId")
                );

            // Self-relation department
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Departments)
                .WithOne(d => d.ParentDepartment)
                .HasForeignKey(d => d.ParentDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            /** Salary Manager Mappings*/
            modelBuilder.Entity<SalaryDelta>()
                .HasOne(p => p.Group)
                .WithMany(p => p.SalaryDeltas)
                .HasForeignKey(p => p.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<SalaryFormula>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<SalaryVariable>()
                .HasIndex(p => p.Name)
                .IsUnique();

            modelBuilder.Entity<SalaryGroup>()
                .HasOne(p => p.Group)
                .WithMany(p => p.SalaryGroups)
                .HasForeignKey(p => p.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // 1-M User-Payslip
            modelBuilder.Entity<User>()
                .HasMany(p => p.Payslips)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmployeeId);

            // 1-M Payroll-Payslip
            modelBuilder.Entity<Payroll>()
                .HasMany(p => p.PayslipList)
                .WithOne(p => p.Payroll)
                .HasForeignKey(p => p.PayrollId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<User>()
                .HasMany(p => p.Notifications)
                .WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserNotification",
                    left => left.HasOne<Notification>()
                        .WithMany()
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade),
                    right => right.HasOne<User>()
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientCascade),
                    je => je.HasKey("NotificationId", "UserId")
                );

            modelBuilder.Entity<Payslip>()
                .HasMany(p => p.SalaryDeltas)
                .WithOne(p => p.Payslip)
                .HasForeignKey(p => p.PayslipId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payslip>()
                .HasMany(p => p.Timekeepings)
                .WithOne(p => p.Payslip)
                .HasForeignKey(p => p.PayslipId)
                .OnDelete(DeleteBehavior.Cascade);


            /** Virtual Space Mappings */
            modelBuilder.Entity<Team>()
                .HasMany(p => p.TaskBoards)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskBoard>()
                .HasMany(p => p.TaskColumns)
                .WithOne(p => p.Board)
                .HasForeignKey(p => p.BoardId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskBoard>()
                .HasMany(p => p.TaskLabels)
                .WithOne(p => p.TaskBoard)
                .HasForeignKey(p => p.TaskBoardId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskColumn>()
                .HasMany(p => p.Tasks)
                .WithOne()
                .HasForeignKey(p => p.ColumnId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Task>()
                .HasMany(p => p.Labels)
                .WithMany(p => p.Tasks)
                .UsingEntity<Dictionary<string, object>>(
                    "TaskTaskLabel",
                    right => right.HasOne<TaskLabel>()
                        .WithMany()
                        .HasForeignKey("TaskLabelId")
                        .OnDelete(DeleteBehavior.Cascade),
                    left => left.HasOne<Task>().WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.ClientCascade),
                    je => je.HasKey("TaskId", "TaskLabelId")
                );

            modelBuilder.Entity<Task>()
                .HasMany(p => p.TaskHistories)
                .WithOne()
                .HasForeignKey(p => p.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskHistory>()
                .HasOne(p => p.TaskFileHistory)
                .WithOne()
                .HasForeignKey<TaskFileHistory>(p => p.TaskHistoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskHistory>()
                .HasOne(p => p.TaskCommentHistory)
                .WithOne()
                .HasForeignKey<TaskCommentHistory>(p => p.TaskHistoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskHistory>()
                .HasOne(p => p.TaskLabelHistory)
                .WithOne()
                .HasForeignKey<TaskLabelHistory>(p => p.TaskHistoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Task>()
                .HasMany(p => p.Comments)
                .WithOne(p => p.Task)
                .HasForeignKey(p => p.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Task>()
                .HasMany(p => p.Files)
                .WithOne(p => p.Task)
                .HasForeignKey(p => p.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            /** Timekeepings Mappings */
            // Many to many User - WorkingShiftEvent
            modelBuilder.Entity<User>()
               .HasMany(p => p.WorkingShiftEvents)
               .WithMany(p => p.Users)
               .UsingEntity<Dictionary<string, object>>(
                   "WorkingShiftEventUser",
                   left => left.HasOne<WorkingShiftEvent>().WithMany().HasForeignKey("WorkingShiftEventId"),
                   right => right.HasOne<User>().WithMany().HasForeignKey("UserId")
               );

            // One to many User - WorkingShift
            modelBuilder.Entity<User>()
                .HasMany(u => u.Timekeepings)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmployeeId);

            // One to many WorkingShiftTimekeeping - WorkingShiftEvent
            modelBuilder.Entity<WorkingShiftTimekeeping>()
                .HasOne(p => p.WorkingShiftEvent)
                .WithMany(p => p.Timekeepings)
                .HasForeignKey(p => p.WorkingShiftEventId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            seedData(modelBuilder);
        }

        private void seedData(ModelBuilder modelBuilder)
        {
            var administrationDataSeeder = new AdministrationDataSeeder(modelBuilder);
            var users = administrationDataSeeder.Users;

            administrationDataSeeder.SeedData();

            new TimekeepingDataSeeder(modelBuilder, users)
                .SeedData();

            new SalaryManagementDataSeeder(modelBuilder)
                .SeedData();

            new VirtualSpaceDataseeder(modelBuilder)
                .SeedData();
        }
    }
}
