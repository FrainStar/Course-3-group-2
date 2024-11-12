
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "Filename=./DatabaseContext.db");
        }

        
        public DbSet<UserModel> Users { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
            modelBuilder.Entity<OrderModel>()
                .HasKey(o => o.Id);
            modelBuilder.Entity<UserModel>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<ProductModel>()
                .HasKey(p => p.Id); 
        }
    }
}

