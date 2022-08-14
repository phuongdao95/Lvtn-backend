using lvtn_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace lvtn_backend.DataContext
{
    public class EmsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Department> Departments { get; set; }

        public EmsContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Manually configure one-to-one reletion Team-User
            modelBuilder.Entity<User>()
                .HasOne<Team>(u => u.Team)
                .WithOne(t => t.Leader)
                .HasForeignKey<Team>(t => t.LeaderId);

            // Self-relation department
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Departments)
                .WithOne(d => d.ParentDepartment)
                .HasForeignKey(d => d.ParentDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
