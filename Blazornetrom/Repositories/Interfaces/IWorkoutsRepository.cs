using Blazornetrom.DTOs;
using Blazornetrom.Entites;

namespace Blazornetrom.Repositories.Interfaces
{
    public interface IWorkoutsRepository {
        IList<WorkoutsDTO> GetAll();

        void AddWorkout(WorkoutsDTO workoutsDTO);

        WorkoutsDTO? GetById(int id);

        void UpdateWorkouts(WorkoutsDTO workouts);

        void DeleteWorkouts(int id);
        public IList<WorkoutsDTO> GetWorkoutsByUserId(int id);


    }
}
