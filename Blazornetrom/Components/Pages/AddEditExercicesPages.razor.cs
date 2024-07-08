using Blazornetrom.DTOs;
using Blazornetrom.Entites;
using Blazornetrom.Migrations;
using Blazornetrom.Repositories.Imlplementations;
using Blazornetrom.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Blazornetrom.Components.Pages
{
    public partial class AddEditExercicesPages : ComponentBase
    {
        [Parameter]
        public int? ExerciseId { get; set; }

        [Inject]
        public IExercicesRepository ExercicesRepository { get; set; }= default!;




        [SupplyParameterFromForm]
        public ExerciesDTO exerciesDTO { get; set; } = new();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public string Title { get; set; } = string.Empty;

        private bool IsEdit = false;

        private void SaveExercies()
        {
            if (IsEdit)
            {
                ExercicesRepository.UpdateExercies(exerciesDTO);
            }
            else
            {
                ExercicesRepository.AddExercies(exerciesDTO);
            }

            NavigationManager.NavigateTo("/exercies");
        }
        protected override void OnParametersSet()
        {
            if (ExerciseId != null)
            {
                exerciesDTO = ExercicesRepository.GetById(ExerciseId.Value);
                Title = "Exerxies user";
                IsEdit = true;
            }
            else
            {
                Title = "Add new exercies";
            }
        }

    }
}