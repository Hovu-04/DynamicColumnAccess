using Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Intern> Interns { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<AllowAccess> AllowAccesses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Mối quan hệ 1-1 giữa User và Role
        modelBuilder.Entity<User>()
            .HasOne<Role>()
            .WithMany()
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Cascade); // Xóa vai trò sẽ xóa người dùng

        // Mối quan hệ 1-n giữa Role và AllowAccess
        modelBuilder.Entity<Role>()
            .HasMany<AllowAccess>()
            .WithOne()
            .HasForeignKey(a => a.RoleId)
            .OnDelete(DeleteBehavior.Cascade); // Xóa vai trò sẽ xóa quyền truy cập
    }
}