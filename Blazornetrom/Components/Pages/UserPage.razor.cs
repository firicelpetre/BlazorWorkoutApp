using Blazorise.DataGrid;
using Blazornetrom.DTOs;
using Blazornetrom.Entites;
using Blazornetrom.Repositories.Imlplementations;
using Blazornetrom.Repositories.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Blazornetrom.Components.Pages
{
    public partial class UserPage : ComponentBase
    {
        [Inject]
        public IUserRepository UserRepo { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        private DeleteConfirmationDialog DeleteConfirmation;


        public List<UsersDTO> UserData = default!;

        private UsersDTO SelectedUser;


        protected override void OnInitialized()
        {
            UserData = UserRepo.GetAll().ToList();
        }

        private void OnAddButtonClicked()
        {
            NavigationManager.NavigateTo($"/users/add");
        }

        private void OnSeeUser(EditCommandContext<UsersDTO> context)
        {
            NavigationManager.NavigateTo($"/workouts/{context.Item.Id}");
        }
        private void OnEditButtonClicked(EditCommandContext<UsersDTO> context)
        {
            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/users/edit/{context.Item.Id}");
            }
        }
        private void OnDeleteButtonClicked(CommandContext<UsersDTO?> context)
        {
            SelectedUser = context.Item;
            if (DeleteConfirmation is null || SelectedUser is null)
            {
                return;
            }

            DeleteConfirmation.Show();
        }
        private async Task HandleDeleteConfirmed(bool confirmed)
        {
            if (SelectedUser != null)
            {
                UserRepo.DeleteUser(SelectedUser.Id);
                OnInitialized();
            }
        }

        private void OnAddWorkoutButtonClicked(EditCommandContext<UsersDTO> context)
        {
            if (context != null && context.Item != null)
            {
                NavigationManager.NavigateTo($"/workout/add/{context.Item.Id}");
            }
        }

    }
}
