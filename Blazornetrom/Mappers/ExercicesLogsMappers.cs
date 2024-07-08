using Blazornetrom.DTOs;
using Blazornetrom.Entites;

namespace Blazornetrom.Mappers
{
    public class ExercicesLogsMappers
    {
        public static ExercicesLogsDTO ToExercicesLogsDto(ExercicesLogs exercicesLogs)
        {
            return new ExercicesLogsDTO
            {
                Id = exercicesLogs.Id,
                Reps = exercicesLogs.Reps,
                Duration = exercicesLogs.Duration,
                ExerciseId = exercicesLogs.ExerciseId,
                Exercises = exercicesLogs.Exercises ,
                WorkoutId = exercicesLogs.WorkoutId,
                Workouts = exercicesLogs.Workouts,
            };
        }

        public static ExercicesLogs ToExercicesLogs(ExercicesLogsDTO exercicesLogsDTO)
        {
            return new ExercicesLogs
            {
                Id = exercicesLogsDTO.Id,
                Reps = exercicesLogsDTO.Reps,
                Duration = exercicesLogsDTO.Duration,
                ExerciseId = exercicesLogsDTO.ExerciseId,
                
                Exercises = exercicesLogsDTO.Exercises, 
                WorkoutId = exercicesLogsDTO.WorkoutId,
                Workouts = exercicesLogsDTO.Workouts ,
            };
        }
    }
}
