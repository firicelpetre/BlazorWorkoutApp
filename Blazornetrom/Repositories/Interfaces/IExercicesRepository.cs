using Blazornetrom.DTOs;
using Blazornetrom.Entites;
using Blazornetrom.Migrations;

namespace Blazornetrom.Repositories.Interfaces
{
    public interface IExercicesRepository
    {
      

        IList<ExerciesDTO> GetAll();

        ExerciesDTO? GetById(int id);

        void UpdateExercies(ExerciesDTO exercies);

        void AddExercies(ExerciesDTO exercies);

        void DeleteExercies(int id);
    }
}
