using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1.Models;

public class TaskContext : DbContext
{
    
    public TaskContext(DbContextOptions<TaskContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<TaskItem> Tasks { get; set; } = null!;
}