using Blazornetrom.Context;
using Blazornetrom.DTOs;
using Blazornetrom.Entites;
using Blazornetrom.Mappers;
using Blazornetrom.Migrations;
using Blazornetrom.Repositories.Interfaces;

namespace Blazornetrom.Repositories.Imlplementations
{
    public class ExercicesRepository : IExercicesRepository
    {
        public readonly SmartWorkoutContext _context;
        public ExercicesRepository(SmartWorkoutContext context)
        {
            _context = context;
        }


        public void AddExercies(ExerciesDTO exerciesDTO)
        {
            var exerciesToAdd = ExerciesMapper.ToExercies(exerciesDTO);

            _context.Exercises.Add(exerciesToAdd);
            _context.SaveChanges();
        }
        public void DeleteExercies(int id)
        {
            var existingExercise = _context.Exercises.Find(id);
            if (existingExercise != null)
            {
                _context.Exercises.Remove(existingExercise);
                _context.SaveChanges();
            }
        }

        public void UpdateExercies(ExerciesDTO exercies)
        {
            var existingExercies = _context.Exercises.Find(exercies.Id);
            if (existingExercies != null)
            {
                existingExercies.Id = exercies.Id;
                existingExercies.Description = exercies.Description;
                existingExercies.Type = exercies.Type;
                existingExercies.ExercicesLogs = exercies.ExerciseLogs;
                _context.Exercises.Update(existingExercies);
                _context.SaveChanges();
            }
        }
        public IList<ExerciesDTO> GetAll()
        {
            return _context.Exercises.Select(u => ExerciesMapper.ToExerciesDTO(u)).ToList();
        }

        public ExerciesDTO? GetById(int id)
        {
            Exercises? exercises = _context.Exercises.Find(id);
            if (exercises != null)
            {
                return ExerciesMapper.ToExerciesDTO(exercises);
            }
            return null;
        }

    }
}
