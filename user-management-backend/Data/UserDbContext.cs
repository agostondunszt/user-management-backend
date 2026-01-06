using Microsoft.EntityFrameworkCore;
using user_management_backend.Models;

namespace user_management_backend.Data;

public class UserDbContext : DbContext
{
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "John Doe", Age = 42, Gender = "Male" },
            new User { Id = 2, Name = "Jane Doe", Age = 21, Gender = "Female" },
            new User { Id = 3, Name = "Jane Smith", Age = 31, Gender = "Female" },
            new User { Id = 4, Name = "John Smith", Age = 34, Gender = "Male" },
            new User { Id = 5, Name = "Eric Widget", Age = 41, Gender = "Male" }
        );
    }
}