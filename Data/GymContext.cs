using GymApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GymApi.Data
{
    public class GymContext : DbContext
    {
        public GymContext(DbContextOptions<GymContext> options) : base(options)
        {

        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<ExerciseList> ExerciseLists { get; set; }
        public DbSet<GymMembers> Members { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<TrainingPlan> TrainingPlans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainingPlan>(entity =>
            {
                entity.Property(e => e.UpdatedAt).ValueGeneratedOnAddOrUpdate();
                entity.Property(e => e.CreatedAt).ValueGeneratedOnAdd();
            });
        }
    }
}
