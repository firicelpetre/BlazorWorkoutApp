using Blazornetrom.Context;
using Blazornetrom.DTOs;
using Blazornetrom.Entites;
using Blazornetrom.Mappers;
using Blazornetrom.Repositories.Interfaces;

namespace Blazornetrom.Repositories.Imlplementations
{
    public class ExerciseLogsRepository : IExerciseLogsRepository
    {
        public readonly SmartWorkoutContext _context;
        public ExerciseLogsRepository(SmartWorkoutContext context)
        {
            _context = context;
        }
        public IList<ExercicesLogsDTO> GetAll()
        {
            return _context.ExercicesLogs.Select(u => ExercicesLogsMappers.ToExercicesLogsDto(u)).ToList();
        }
        public ExercicesLogsDTO? GetById(int id)
        {
            ExercicesLogs? exercicesLogs = _context.ExercicesLogs.Find(id);
            if (exercicesLogs != null)
            {
                return ExercicesLogsMappers.ToExercicesLogsDto(exercicesLogs);
            }
            return null;
        }
        public void UpdateExercicesLogs(ExercicesLogsDTO exercicesLogsDTO)
        {
            var existingExercicesLogs = _context.ExercicesLogs.Find(exercicesLogsDTO.Id);
            if (existingExercicesLogs != null)
            {
                existingExercicesLogs.Reps = exercicesLogsDTO.Reps;
                existingExercicesLogs.Duration = exercicesLogsDTO.Duration;
                existingExercicesLogs.ExerciseId = exercicesLogsDTO.ExerciseId;
                existingExercicesLogs.Exercises = exercicesLogsDTO.Exercises;
                existingExercicesLogs.WorkoutId = exercicesLogsDTO.WorkoutId;
                existingExercicesLogs.Workouts = exercicesLogsDTO.Workouts;
                existingExercicesLogs.Id = exercicesLogsDTO.Id;
                _context.ExercicesLogs.Update(existingExercicesLogs);
                _context.SaveChanges();
            }
        }
        public void AddExercicesLogs(ExercicesLogsDTO exercicesLogsDTO)
        {
            var ExercicesLogsToAdd = ExercicesLogsMappers.ToExercicesLogs(exercicesLogsDTO);



            _context.ExercicesLogs.Add(ExercicesLogsToAdd);
            _context.SaveChanges();
        }
        public void DeleteExercicesLogs(int id)
        {
            var existingExercicesLogs = _context.ExercicesLogs.Find(id);
            if (existingExercicesLogs != null)
            {
                _context.ExercicesLogs.Remove(existingExercicesLogs);
                _context.SaveChanges();
            }
        }
    }
}
