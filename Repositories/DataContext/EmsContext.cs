using Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Models.Repositories.DataContext
{
    public class EmsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Department> Departments { get; set; }

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
                .WithMany(t => t.Members);

            // 1-1 User-BankInfo
            modelBuilder.Entity<User>()
                .HasOne<BankInfo>(u => u.BankInfo)
                .WithOne()
                .HasForeignKey<User>(u => u.BankInfoId);

            // 1-M User-Workday
            modelBuilder.Entity<User>()
                .HasMany<Workday>(u => u.Workdays)
                .WithOne();
            modelBuilder.Entity<Workday>()
                .HasOne<User>()
                .WithMany(u => u.Workdays);

            // Self-relation department
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Departments)
                .WithOne(d => d.ParentDepartment)
                .HasForeignKey(d => d.ParentDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            // M-M User-DeductionAllowanceBonus
            modelBuilder.Entity<User>()
                .HasMany<DeductionAllowanceBonus>(u => u.DeductionAllowanceBonuses)
                .WithMany(d => d.Users);

            // 1-M DeductionAllowanceBonusTemplate-DeductionAllowanceBonus
            modelBuilder.Entity<DeductionAllowanceBonus>()
                .HasOne<DeductionAllowanceBonusTemplate>(dab => dab.Template)
                .WithMany()
                .HasForeignKey(dab => dab.TemplateId);

            // 1-M Formula-Template
            modelBuilder.Entity<DeductionAllowanceBonusTemplate>()
                .HasOne<Formula>(dt => dt.Formula)
                .WithMany(f => f.Templates)
                .HasForeignKey(dt => dt.FormulaId);

            // M-M Formula-Constant
            modelBuilder.Entity<Formula>()
                .HasMany<Constant>(f => f.Constants)
                .WithMany(c => c.Formulas);

            // M-M Formula-Input
            modelBuilder.Entity<Formula>()
                .HasMany<Input>(f => f.Inputs)
                .WithMany(c => c.Formulas);

            // 1-M User-Payslip
            modelBuilder.Entity<User>()
                .HasMany<Payslip>(u => u.Payslips)
                .WithOne(p => p.Employee)
                .HasForeignKey(p => p.EmployeeId);
        }
    }
}
