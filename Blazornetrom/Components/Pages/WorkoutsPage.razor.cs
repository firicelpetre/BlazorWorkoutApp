using Blazorise.DataGrid;
using Blazornetrom.DTOs;
using Blazornetrom.Entites;
using Blazornetrom.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Blazornetrom.Components.Pages
{
    public partial class WorkoutsPage: ComponentBase
    {
        [Parameter]
        public int? WorkoutId { get; set; }


        [Inject]
        public IWorkoutsRepository WorkoutsRepo { get; set; } = default;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        private DeleteConfirmationDialog DeleteConfirmation;

        public List<WorkoutsDTO> WorkoutData = default!;

        private WorkoutsDTO SelectedWorkout;

        protected override void OnInitialized()
        {
            WorkoutData = WorkoutsRepo.GetAll().ToList();
        }

        private void OnAddButtonClicked()
        {
            NavigationManager.NavigateTo($"/workouts/add");
        }
        private void OnEditButtonClicked(EditCommandContext<WorkoutsDTO> context)
        {
            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/workouts/edit/{context.Item.Id}");
            }
        }
        private void OnDeleteButtonClicked(CommandContext<WorkoutsDTO?> context)
        {
            SelectedWorkout = context.Item;
            if (DeleteConfirmation is null || SelectedWorkout is null)
            {
                return;
            }

            DeleteConfirmation.Show();
        }
        private void OnSeeExerciesLogs(EditCommandContext<WorkoutsDTO> context)
        {
            NavigationManager.NavigateTo($"/exercieslogs/{context.Item.Id}");
        }
        private async Task HandleDeleteConfirmed(bool confirmed)
        {
            if (SelectedWorkout != null)
            {
                WorkoutsRepo.DeleteWorkouts(SelectedWorkout.Id);
                OnInitialized();
            }
        }

        private void OnAddWorkoutButtonClicked(EditCommandContext<WorkoutsDTO> context)
        {
            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/exerciceslogs/add/{context.Item.Id}");
            }
        }
    }
}
