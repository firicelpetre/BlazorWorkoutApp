using Blazornetrom.Context;
using Blazornetrom.DTOs;
using Blazornetrom.Entites;
using Blazornetrom.Mappers;
using Blazornetrom.Migrations;
using Blazornetrom.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Blazornetrom.Repositories.Imlplementations
{
    public class WorkoutsRepository: IWorkoutsRepository
    {
        public readonly SmartWorkoutContext _context;
        public WorkoutsRepository(SmartWorkoutContext context) { 
             _context = context;

        
        }
        public IList<WorkoutsDTO> GetAll()
        {
            return _context.Workouts.Select(u => WorkoutsMapper.ToWorkoutDto(u)).ToList();
        }

        public WorkoutsDTO? GetById(int id)
        {
            Workouts? workouts = _context.Workouts.Find(id);
            if (workouts != null)
            {
                return WorkoutsMapper.ToWorkoutDto(workouts);
            }
            return null;
        }

        public void UpdateWorkouts(WorkoutsDTO workouts)
        {
            var existingWorkouts = _context.Workouts.Find(workouts.Id);
            if (existingWorkouts != null)
            {
                existingWorkouts.UserId = workouts.UsersId;
                existingWorkouts.Name = workouts.Name;
                existingWorkouts.Date = workouts.Date;
                existingWorkouts.Users = workouts.Users;
                existingWorkouts.ExercicesLogs = existingWorkouts.ExercicesLogs;
                _context.Workouts.Update(existingWorkouts);
                _context.SaveChanges();
            }
        }
        public void AddWorkout(WorkoutsDTO workoutsDTO)
        {
            var workoutToAdd = WorkoutsMapper.ToWorkout(workoutsDTO);

            _context.Workouts.Add(workoutToAdd);
            _context.SaveChanges();
        }

        public void DeleteWorkouts(int id)
        {
            var existingWorkouts = _context.Workouts.Find(id);
            if (existingWorkouts != null)
            {
                _context.Workouts.Remove(existingWorkouts);
                _context.SaveChanges();
            }
        }
        

        public IList<WorkoutsDTO> GetWorkoutsByUserId(int id)
        {

            var workouts = new List<WorkoutsDTO>();
            var allWorkouts = _context.Workouts.Where(w => w.UserId == id).Include(x => x.Users).ToList();
            if (allWorkouts?.Any() == true)
            {
                foreach (var workout in allWorkouts)
                {
                    var workoutDto = WorkoutsMapper.ToWorkoutDto(workout);
                    workouts.Add(workoutDto);
                }
            }

            return workouts;

        }

    }
}
