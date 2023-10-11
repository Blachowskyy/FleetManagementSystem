using FleetManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagementSystem.Services.DataBase
{
    public class FMSDbContext : DbContext
    {
        public DbSet<AppSettings> AppSettings { get; set; }
        public DbSet<Forklift> Forklifts { get; set;}
        public DbSet<Location> Locations { get; set; }
        public DbSet<JobStep> Tasks { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<ForkliftLog> Logs { get; set; }

        public FMSDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>()
                .HasMany(j => j.TaskList)
                .WithOne(js => js.Job)
                .HasForeignKey(js => js.JobID);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
