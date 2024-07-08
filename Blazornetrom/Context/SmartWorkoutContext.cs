using Blazornetrom.Entites;
using Microsoft.EntityFrameworkCore;

namespace Blazornetrom.Context
{
    public class SmartWorkoutContext: DbContext
    {
        public SmartWorkoutContext(DbContextOptions<SmartWorkoutContext> options)
        : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Exercises> Exercises { get; set;}

        public DbSet<Workouts> Workouts { get; set; }

        public DbSet<ExercicesLogs> ExercicesLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workouts>()
                .HasOne(w => w.Users)
                .WithMany(u => u.Workouts)
                .HasForeignKey(w => w.UserId)
                .HasConstraintName("FK_Worksouts_Users");

            modelBuilder.Entity<ExercicesLogs>()
              .HasOne(el => el.Exercises)
              .WithMany(e => e.ExercicesLogs)
              .HasForeignKey(el => el.ExerciseId)
              .HasConstraintName("FK_ExercicesLogs_Exercices");

            modelBuilder.Entity<ExercicesLogs>()
             .HasOne(el => el.Workouts)
             .WithMany(w => w.ExercicesLogs)
             .HasForeignKey(el => el.WorkoutId)
             .HasConstraintName("FK_ExercicesLogs_Workouts");

            base.OnModelCreating(modelBuilder);

        }
    }
}
