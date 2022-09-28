using Models.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.DataContext.DataSeeder;

namespace Models.Repositories.DataContext
{
    public class EmsContext : DbContext
    {
        /** Administration Module */
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        /** Salary Management */
        public DbSet<Payroll> Payrolls { get; set; } 
        public DbSet<SalaryDelta> SalaryDeltas{ get; set; } 
        public DbSet<SalaryDeltaFormula> SDFormulas { get; set; }
        public DbSet<SalaryDeltaVariable> SDFormulaConstants { get; set; }

        public EmsContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1-1 Team-User (1 Team managed by one User)
            modelBuilder.Entity<User>()
                .HasOne<Team>(u => u.TeamManage)
                .WithOne(t => t.Leader)
                .HasForeignKey<Team>(t => t.LeaderId);

            // 1-M Team-User (many Users belong to 1 Team)
            modelBuilder.Entity<User>()
                .HasOne<Team>(u => u.TeamBelong)
                .WithMany(t => t.Members)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // 1-1 User-BankInfo
            modelBuilder.Entity<User>()
                .HasOne<BankInfo>(u => u.BankInfo)
                .WithOne()
                .HasForeignKey<User>(u => u.BankInfoId);

            // 1-M User-Workday
            modelBuilder.Entity<User>()
                .HasMany<WorkingShift>(u => u.WorkingShifts)
                .WithOne()
                .HasForeignKey(p => p.EmployeeId)
                ;

            modelBuilder.Entity<WorkingShift>()
                .HasOne<WorkingShiftType>()
                .WithMany(p => p.WorkingShifts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                ;

            // Self-relation department
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Departments)
                .WithOne(d => d.ParentDepartment)
                .HasForeignKey(d => d.ParentDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // M-M User-DeductionAllowanceBonus
            modelBuilder.Entity<User>()
                .HasMany(u => u.SalaryDeltaList)
                .WithMany(d => d.Users);

            // 1-M SalaryDelta-Formula
            modelBuilder.Entity<SalaryDelta>()
                .HasOne(p => p.Formula)
                .WithMany(p => p.SalaryDeltaList)
                .HasForeignKey(p => p.FormulaId)
                ;

            // M-M SalaryDeltaFormula-SalaryDeltaFormulaConstant
            modelBuilder.Entity<SalaryDeltaFormula>()
                .HasMany(f => f.Variables)
                .WithMany(c => c.Formulas)
                .UsingEntity<Dictionary<string, object>>(
                    "SalaryDeltaFormula_SalaryDeltaVariable",
                    right => right.HasOne<SalaryDeltaVariable>()
                        .WithMany()
                        .HasForeignKey("SalaryDeltaFormulaId"),
                    left => left.HasOne<SalaryDeltaFormula>()
                        .WithMany()
                        .HasForeignKey("SalaryDeltaVariableId"),
                    je => je.HasKey("SalaryDeltaFormulaId", "SalaryDeltaVariableId")
                );

            // 1-M User-Payslip
            modelBuilder.Entity<User>()
                .HasMany(p => p.Payslips)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmployeeId);

            // 1-M Payroll-Payslip
            modelBuilder.Entity<Payroll>()
                .HasMany(p => p.PayslipList)
                .WithOne(p => p.Payroll)
                .HasForeignKey(p => p.PayrollId);

            // 1-M User-Role
            modelBuilder.Entity<User>()
                .HasOne(p => p.Role)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.RoleId);

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


            new AdministrationDataSeeder(modelBuilder).SeedData();
        }
    }
}
