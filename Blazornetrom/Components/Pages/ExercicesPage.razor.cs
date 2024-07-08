using Blazorise.DataGrid;
using Blazornetrom.DTOs;
using Blazornetrom.Entites;
using Blazornetrom.Repositories.Imlplementations;
using Blazornetrom.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Blazornetrom.Components.Pages
{
    public partial class ExercicesPage : ComponentBase
    {
        private ExerciesDTO SelectedExercise;
        [Inject]
        public IExercicesRepository ExercicesRepository { get; set; } = default!;


        public List<ExerciesDTO> Exercises { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        

        public DeleteConfirmationDialog DeleteConfirmation;
        protected override void OnInitialized()
        {
            Exercises = ExercicesRepository.GetAll().ToList();
        }
        private void OnAddButtonClicked()
        {
            NavigationManager.NavigateTo($"/exercies/add");
        }

        private void EditExercies(EditCommandContext<ExerciesDTO> context)
        {
            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/exercies/edit{context.Item.Id}");


            }


        }
        private void OnEditButtonClicked(EditCommandContext<ExerciesDTO> context)
        {
            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/exercies/edit/{context.Item.Id}");
            }
        }
        private void OnDeleteButtonClicked(CommandContext<ExerciesDTO?> context)
        {
            SelectedExercise = context.Item;
            if (DeleteConfirmation is null || SelectedExercise is null)
            {
                return;
            }

            DeleteConfirmation.Show();
        }

        private async Task HandleDeleteConfirmed(bool confirmed)
        {
            if (SelectedExercise != null)
            {
                ExercicesRepository.DeleteExercies(SelectedExercise.Id);
                OnInitialized();
            }
        }
        
        



    }
}
