using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GDPAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GDPAPI.Persistence.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
    }
}
