using Blazornetrom.DTOs;
using Blazornetrom.Entites;

namespace Blazornetrom.Repositories.Interfaces
{
    public interface IExerciseLogsRepository
    {
        IList<ExercicesLogsDTO> GetAll();

        void AddExercicesLogs(ExercicesLogsDTO exercicesLogsDTO);

        ExercicesLogsDTO? GetById(int id);

        void UpdateExercicesLogs(ExercicesLogsDTO exercicesLogsDTO);

        void DeleteExercicesLogs(int id);

		public IList<ExercicesLogsDTO> GetExercicesLogsByWorkoutsId(int id);
	}
}
