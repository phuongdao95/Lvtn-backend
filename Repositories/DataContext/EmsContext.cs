using lvtn_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace lvtn_backend.Repositories.DataContext
{
    public class EmsContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Department> Departments { get; set; }

        public EmsContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Manually configure one-to-one reletion Team-User (1 Team managed by one User)
            modelBuilder.Entity<User>()
                .HasOne<Team>(u => u.TeamManage)
                .WithOne(t => t.Leader)
                .HasForeignKey<Team>(t => t.LeaderId);

            // Manually configure one-to-many relation Team-User (many Users belong to 1 Team)
            modelBuilder.Entity<User>()
                .HasOne<Team>(u => u.TeamBelong)
                .WithMany(t => t.Members);

            // Self-relation department
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Departments)
                .WithOne(d => d.ParentDepartment)
                .HasForeignKey(d => d.ParentDepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
