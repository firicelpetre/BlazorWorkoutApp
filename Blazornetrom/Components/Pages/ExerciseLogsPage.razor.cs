﻿using Blazorise.DataGrid;
using Blazornetrom.DTOs;
using Blazornetrom.Entites;
using Blazornetrom.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Blazornetrom.Components.Pages
{
    public partial class ExerciseLogsPage : ComponentBase


    {
		[Parameter]
		public int? WorkoutId { get; set; }

		[Inject]
        public IExerciseLogsRepository exerciseLogsRepository { get; set; } = default;

		[Inject]
		public IWorkoutsRepository workoutsRepository { get; set; } = default;

		[Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        private DeleteConfirmationDialog DeleteConfirmation;

        public List<ExercicesLogsDTO> ExerciesLogsData = default!;

        private ExercicesLogsDTO SelectedExercicesLogs;

       

		protected override void OnInitialized()
		{
			if (WorkoutId == null)
			{
				ExerciesLogsData = exerciseLogsRepository.GetAll().ToList();
			}
			else
			{

				ExerciesLogsData = exerciseLogsRepository.GetExercicesLogsByWorkoutsId(WorkoutId.Value).ToList();
			}
		}
		private void OnAddButtonClicked()
        {
            NavigationManager.NavigateTo($"/exerciceslogs/add");
        }

        
        private void OnEditButtonClicked(EditCommandContext<ExercicesLogsDTO> context)
        {
            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/exerciceslogs/{context.Item.Id}");
            }
        }
        private void OnDeleteButtonClicked(CommandContext<ExercicesLogsDTO?> context)
        {
            SelectedExercicesLogs = context.Item;
            if (DeleteConfirmation is null || SelectedExercicesLogs is null)
            {
                return;
            }

            DeleteConfirmation.Show();
        }
        private async Task HandleDeleteConfirmed(bool confirmed)
        {
            if (SelectedExercicesLogs != null)
            {
                exerciseLogsRepository.DeleteExercicesLogs(SelectedExercicesLogs.Id);
                OnInitialized();
            }
        }
    }
}
