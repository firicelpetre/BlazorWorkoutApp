using Blazornetrom.DTOs;
using Blazornetrom.Entites;

namespace Blazornetrom.Mappers
{
    public class WorkoutsMapper
    {
        public static Workouts ToWorkout(WorkoutsDTO workoutsDTO)
        {
            return new Workouts
            {
                UserId = workoutsDTO.UsersId,
                Name = workoutsDTO.Name,
                Date = workoutsDTO.Date,
                Users = workoutsDTO.Users,
                Id = workoutsDTO.Id
            };
        }

        public static WorkoutsDTO ToWorkoutDto(Workouts workouts)
        {
            return new WorkoutsDTO
            {
                UsersId = workouts.UserId,
                Name = workouts.Name,
                Date = workouts.Date,
                Users = workouts.Users,
                Id = workouts.Id
            };
        }
    }
}
