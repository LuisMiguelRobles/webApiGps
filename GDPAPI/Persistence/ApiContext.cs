using GDPAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GDPAPI.Persistence.Context
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasKey(user => new { user.Id });
            modelBuilder.Entity<User>().Property(user => user.Name).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.LastName).IsRequired();
            modelBuilder.Entity<User>().Property(user => user.Email).IsRequired();
            modelBuilder.Entity<User>().HasIndex(user => user.Email).IsUnique();
            modelBuilder.Entity<User>().Property(user => user.Password).IsRequired();
        }

        
    }
}
