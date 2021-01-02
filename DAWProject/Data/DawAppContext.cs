using DAWProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DAWProject.Data
{
    public class DawAppContext : DbContext
    {
        public DawAppContext(DbContextOptions<DawAppContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(user => user.Contract)
                .WithOne(contract => contract.Employee)
                .HasForeignKey<Contract>(contract => contract.EmployeeId)
                .IsRequired(false);

            modelBuilder.Entity<User>()
                .HasOne(user => user.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(user => user.RoleId)
                .IsRequired(false);
            
            modelBuilder.Entity<User>()
                .HasOne(user => user.Department)
                .WithMany(department => department.Employees)
                .HasForeignKey(user => user.DepartmentId)
                .IsRequired(false);
            
            modelBuilder.Entity<User>()
                .HasOne(user => user.Team)
                .WithMany(team => team.Employees)
                .HasForeignKey(user => user.TeamId)
                .IsRequired(false);

            modelBuilder.Entity<Role>()
                .HasMany(role => role.Users)
                .WithOne(user => user.Role)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Department>()
                .HasMany(department => department.Employees)
                .WithOne(user => user.Department)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Team>()
                .HasMany(team => team.Employees)
                .WithOne(user => user.Team)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<UserProject>()
                .HasKey(et => new { et.UserId, et.ProjectId });
             modelBuilder.Entity<UserProject>()
                .HasOne(up => up.User)
                .WithMany(user => user.Projects)
                .HasForeignKey(up => up.UserId);  
             modelBuilder.Entity<UserProject>()
                .HasOne(up => up.Project)
                .WithMany(p => p.Users)
                .HasForeignKey(up => up.UserId);  

            base.OnModelCreating(modelBuilder);
        }

    }
}
