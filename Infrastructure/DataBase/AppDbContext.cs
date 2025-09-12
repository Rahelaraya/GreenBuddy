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

        // AppDbContext.cs
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CareLogs>(entity =>
            {
                entity.ToTable("CareLogs", "dbo"); // adjust schema if needed
                entity.HasKey(e => e.Id);

                // Map the property "Date" in the entity to the actual column name in DB:
                entity.Property(e => e.Date)
                      .HasColumnName("LogDate")     // <-- CHANGE THIS to your real column name
                      .HasColumnType("datetime2")
                      .IsRequired();

                entity.Property(e => e.Note).HasMaxLength(4000);
                entity.Property(e => e.TaskType).HasMaxLength(100);
            });
        }

    }


}
