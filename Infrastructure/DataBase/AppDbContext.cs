using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<CareLogs> CareLogs { get; set; }
        public DbSet<CareTasks> CareTasks { get; set; }
        public DbSet<Plants> Plants { get; set; }

        // AppDbContext.cs
    }


}
