using Blazornetrom.DTOs;
using Blazornetrom.Entites;

namespace Blazornetrom.Mappers
{
    public class ExerciesMapper
    {
        public static Exercises ToExercies(ExerciesDTO ereciesDto)
        {
            return new Exercises
            {
                Description = ereciesDto.Description,
                Type = ereciesDto.Type,
               
                Id = ereciesDto.Id
            };
        }

        public static ExerciesDTO ToExerciesDTO(Exercises exercises)
        {
            return new ExerciesDTO
            {
                Description = exercises.Description,
                Type = exercises.Type,
                
                Id = exercises.Id
            };
        }
    }
}
