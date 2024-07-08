using Blazornetrom.DTOs;
using Blazornetrom.Entites;
using Blazornetrom.Migrations;
using Blazornetrom.Repositories.Imlplementations;
using Blazornetrom.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Blazornetrom.Components.Pages
{
    public partial class AddEditExercicesLogsPages: ComponentBase
    {
        [Parameter]
        public int? ExercicesLogsId { get; set; }


        [Parameter]
        public int? WorkoutId { get; set; }


        [Inject]
        public IExerciseLogsRepository exerciseLogsRepository { get; set; }

        [Inject]
        public IWorkoutsRepository WorkoutsRepository { get; set; }

        [Inject]
        public IExercicesRepository ExercisesRepository { get; set; }

        [SupplyParameterFromForm]
        public ExercicesLogsDTO exercicesLogsDTO { get; set; } = new ExercicesLogsDTO();

        [SupplyParameterFromForm]
        public WorkoutsDTO workoutsDTO { get; set; } = new();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string Title { get; set; } = string.Empty;

        private bool IsEdit = false;

        private List<WorkoutsDTO> ListWorkouts = new List<WorkoutsDTO>();

        private List<ExerciesDTO> ListExercises = new List<ExerciesDTO>();

        HashSet<string> WorkoutTypes = new HashSet<string>();

        protected List<string> WorkoutTypesList { get; set; }

        protected override void OnParametersSet()
        {
            if (ExercicesLogsId != null)
            {
                exercicesLogsDTO = exerciseLogsRepository.GetById(ExercicesLogsId.Value);
                IsEdit = true;
            }
            else
            {
                exercicesLogsDTO = new ExercicesLogsDTO();
                IsEdit = false;
            }

            if (WorkoutId != null)
            {
                workoutsDTO = WorkoutsRepository.GetById(WorkoutId.Value);
                exercicesLogsDTO.WorkoutId = WorkoutId.Value;
            }

           

            ListExercises = ExercisesRepository.GetAll().ToList();
        }
        private void SaveExerciesLogs()
        {
            if (IsEdit)
            {
                exerciseLogsRepository.UpdateExercicesLogs(exercicesLogsDTO);
            }
            else
            {
                exercicesLogsDTO.WorkoutId = workoutsDTO.Id;
                exerciseLogsRepository.AddExercicesLogs(exercicesLogsDTO);
            }

            NavigationManager.NavigateTo("/exerciceslogs");
        }
    }
}
