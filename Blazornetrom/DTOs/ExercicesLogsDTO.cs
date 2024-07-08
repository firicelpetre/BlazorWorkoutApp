using Blazornetrom.Entites;
using System.ComponentModel.DataAnnotations;

namespace Blazornetrom.DTOs
{
    public class ExercicesLogsDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Reps is required")]
        public int Reps { get; set; }

        [Required(ErrorMessage = "Duration is required")]
        public int Duration { get; set; }

        [Required(ErrorMessage = "ExerciseId is required")]
        public int ExerciseId { get; set; }

       
        public Exercises Exercises { get; set; }

        [Required(ErrorMessage = "WorkoutId is required")]
        public int WorkoutId { get; set; }

       
        public Workouts Workouts { get; set; }

    }
}
