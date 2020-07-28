using Microsoft.EntityFrameworkCore;

namespace WorkoutApp.Domain
{
    public class WorkoutDbContext : DbContext
    {
        public WorkoutDbContext(DbContextOptions<WorkoutDbContext> options) : base(options) 
        {
        }

        public DbSet<Workout> Workouts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkoutConfiguration());
        }
    }
}